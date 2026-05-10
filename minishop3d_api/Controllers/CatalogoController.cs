using Application.Features.Catalogos.Queries.GetEscalas;
using Application.Features.Catalogos.Queries.GetEstadosProducto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{
    [ApiController]
    [Route("minisho3d/catalogo")]
    public class CatalogoController : ControllerBase
    {
        private readonly ISender _sender;

        public CatalogoController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpGet("escalas")]
        public async Task<IActionResult> GetEscalas(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetEscalasQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("estados-producto")]
        public async Task<IActionResult> GetEstadosProducto(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetEstadosProductoQuery(), cancellationToken);
            return Ok(result);
        }
    }
}