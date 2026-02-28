using Application.Auth.Commands.AuthenticateUsuario;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{
    [ApiController]
    [Route("minisho3d/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ICurrentUserService _currentUserService;

        public AuthController(
            ISender sender,
            ICurrentUserService currentUserService
            )
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        [Authorize]
        [HttpPost("login")]
        public async Task<IActionResult> Login(CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAuthenticated)
                return Unauthorized("El usuario no está autenticado.");

            var uid = _currentUserService.FirebaseUid;
            var email = _currentUserService.FirebaseEmail;

            if (uid is null || email is null)
                return BadRequest("El token de autenticación no contiene la información necesaria.");

            var name = _currentUserService.FirebaseUsername;

            var command = new AuthenticateUsuarioCommand(uid, email, name);

            var result = await _sender.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}