using Application.Features.Usuarios.Queries.GetUsuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace minishop3d_api.Controllers
{
    [ApiController]
    [Route("minisho3d/user")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMiUsuarioAsync(CancellationToken cancellationToken)
        {
            var uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new InvalidOperationException("No ha sido encontrado UID en el token.");

            var query = new GetUsuarioQuery(uid);
            var result = await _sender.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}