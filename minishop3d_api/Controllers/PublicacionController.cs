using Application.Features.Publicaciones.Commands.AddPublicacion;
using Application.Features.Publicaciones.Commands.UpdatePublicacionEstado;
using Application.Features.Publicaciones.Queries.GetPublicacion;
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
        [HttpGet("{publicacionId:long:required}")]
        public async Task<IActionResult> GetProductoAsync(
            [FromRoute] long publicacionId,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(new GetPublicacionQuery(publicacionId), cancellationToken);
            return HandleResult(result);
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