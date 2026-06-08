using Application.Features.ProductoPresentaciones.Commands.AddProductoPresentacion;
using Application.Features.ProductoPresentaciones.Commands.CalculateProductoPresentacion;
using Application.Features.ProductoPresentaciones.Commands.UpdateProductoPresentacion;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{

    [ApiController]
    [Route("minisho3d/producto-presentacion")]
    public class ProductoPresentacionController : BaseController
    {
        private readonly ISender _sender;

        public ProductoPresentacionController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProductoPresentacionAsync(
            [FromBody] AddProductoPresentacionCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return HandleResult(result);
        }

        [Authorize]
        [HttpPut("{productoPresentacionId:int:required}")]
        public async Task<IActionResult> UpdateProductoPresentacionAsync(
            [FromRoute] int productoPresentacionId,
            [FromBody] UpdateProductoPresentacionCommand command,
            CancellationToken cancellationToken)
        {
            if(productoPresentacionId != command.ProductoPresentacionId)
            {
                command.ProductoPresentacionId = productoPresentacionId;
            }

            var result = await _sender.Send(command, cancellationToken);
            return HandleResult(result);
        }

        [HttpPost("calculate-presentacion")]
        public async Task<IActionResult> CalculateProductoPresentacionAsync(
            [FromBody] CalculateProductoPresentacionCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return HandleResult(result);
        }
    }
}