using Application.Features.Publicaciones.Commands.AddPublicacion;
using Application.Features.Publicaciones.UpdatePublicacionEstado;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{

    [ApiController]
    [Route("minisho3d/publicacion")]
    public class PublicacionController : BaseController
    {
        private readonly ISender _sender;

        public PublicacionController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPublicacionAsync(
            [FromBody] AddPublicacionCommand command,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(command, cancellationToken);
            return HandleResult(result);
        }

        [Authorize]
        [HttpPatch("actualizar-estado")]
        public async Task<IActionResult> UpdateEstadoPublicacionAsync(
            [FromBody] UpdatePublicacionEstadoCommand command,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(command, cancellationToken);
            return HandleResult(result);
        }
    }
}