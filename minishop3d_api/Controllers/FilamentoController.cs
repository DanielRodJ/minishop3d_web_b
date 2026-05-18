using Application.Features.Filamentos.Queries.GetListaFilamentos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{
    [ApiController]
    [Route("minisho3d/filamento")]
    public class FilamentoController : ControllerBase
    {
        private readonly ISender _sender;

        public FilamentoController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpGet("lista-filamentos")]
        public async Task<IActionResult> GetListaFilamentosAsync(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetListaFilamentosQuery(), cancellationToken);
            return Ok(result);
        }
    }
}