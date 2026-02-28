using Domain.Entities.Usuarios;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Auth.Commands.AuthenticateUsuario
{
    public class AuthenticateUsuarioCommandHandler : IRequestHandler<AuthenticateUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<AuthenticateUsuarioCommandHandler> _logger;

        public AuthenticateUsuarioCommandHandler(
            IUsuarioRepository usuarioRepository,
            ILogger<AuthenticateUsuarioCommandHandler> logger
            )
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public async Task<bool> Handle(AuthenticateUsuarioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando autenticación de usuario para UID: {Uid}", request.Uid);

            var usuario = await _usuarioRepository.GetByUidAsync(request.Uid, cancellationToken);

            // Caso: Un nuevo usuario ha ingresado por primera vez.
            if (usuario is null)
            {
                _logger.LogInformation("Nuevo usuario detectado. Creando registro para: {Email}", request.Email);
                usuario = Usuario.New(request.Uid, request.Name, request.Email, esAdmin: false);
                await _usuarioRepository.AddAsync(usuario, cancellationToken);
            }
            // Caso: Un usuario antiguo ha regresado luego de borrar cuenta.
            else if (usuario.IsDeleted)
            {
                _logger.LogInformation("Usuario antiguo detectado. Reactivando registro para {Uid}", request.Uid);
                usuario.Restore();
                await _usuarioRepository.UpdateAsync(usuario, cancellationToken);
            }

            return true;
        }
    }
}