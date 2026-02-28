using Application.Dtos.Usuarios;
using Domain.Entities.Usuarios;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, UsuarioBaseDto>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<GetUsuarioQueryHandler> _logger;

        public GetUsuarioQueryHandler(
            IUsuarioRepository usuarioRepository,
            ILogger<GetUsuarioQueryHandler> logger
            )
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UsuarioBaseDto> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando obtención de usuario por {TipoId}: {Id}",
                request.UsuarioId.HasValue ? "ID" : "UID",
                request.UsuarioId.HasValue ? request.UsuarioId : request.ExternalId);

            Usuario? usuario;

            if (request.UsuarioId.HasValue)
            {
                usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId.Value, cancellationToken);
            }
            else if (!string.IsNullOrEmpty(request.ExternalId))
            {
                usuario = await _usuarioRepository.GetByUidAsync(request.ExternalId, cancellationToken);
            }
            else
            {
                throw new ArgumentException("Es necesario proporcionar UsuarioId o ExternalId.");
            }

            if (usuario is null)
            {
                throw new KeyNotFoundException(
                    request.UsuarioId.HasValue
                        ? $"No se ha encontrado al usuario con ID {request.UsuarioId}"
                        : $"No se ha encontrado al usuario con UID {request.ExternalId}"
                );
            }

            return new UsuarioBaseDto
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                EsAdmin = usuario.EsAdmin,
                IsDeleted = usuario.IsDeleted,
            };
        }
    }
}