using Application.Features.Catalogos.Queries.GetAcabadosMaterial;
using Application.Features.Catalogos.Queries.GetColoresFilamento;
using Application.Features.Catalogos.Queries.GetEscalas;
using Application.Features.Catalogos.Queries.GetEstadosProducto;
using Application.Features.Catalogos.Queries.GetTiposInsumo;
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

        [HttpGet("acabados-material")]
        public async Task<IActionResult> GetAcabadosMaterial(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetAcabadosMaterialQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("colores-filamento")]
        public async Task<IActionResult> GetColoresFilamento(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetColoresFilamentoQuery(), cancellationToken);
            return Ok(result);
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

        [HttpGet("tipos-insumo")]
        public async Task<IActionResult> Login(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetTiposInsumoQuery(), cancellationToken);
            return Ok(result);
        }
    }
}