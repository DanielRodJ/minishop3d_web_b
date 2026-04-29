using Application.Features.Productos.Commands.AddProducto;
using Application.Features.Productos.Queries.GetProducto;
using Application.Features.Productos.Queries.GetProductos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{
    [Route("minisho3d/producto")]
    public class ProductoController : BaseController
    {
        private readonly ISender _sender;

        public ProductoController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        //[Authorize]
        [HttpGet("{productoId:int:required}")]
        public async Task<IActionResult> GetProductoAsync(
            [FromRoute] int productoId,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(new GetProductoQuery(productoId), cancellationToken);
            return HandleResult(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProductoAsync(
            [FromBody] AddProductoCommand command,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(command, cancellationToken);
            return HandleResult(result);
        }

        [Authorize]
        [HttpGet("productos")]
        public async Task<IActionResult> GetProductosAsync(
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] string? filterBy,
            [FromQuery] string? sortBy,
            [FromQuery] bool? sortDescending,
            CancellationToken cancellationToken
            )
        {
            var result = await _sender.Send(
                new GetProductosQuery(pageNumber, pageSize, searchTerm, filterBy, sortBy, sortDescending),
                cancellationToken
            );

            return HandleResult(result);
        }
    }
}