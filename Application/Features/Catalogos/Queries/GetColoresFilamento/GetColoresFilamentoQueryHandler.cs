using Application.Features.Catalogos.Dtos;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Catalogos.Queries.GetColoresFilamento
{
    public class GetColoresFilamentoQueryHandler : IRequestHandler<GetColoresFilamentoQuery, Result<List<CatalogoDto>>>
    {
        private readonly ILogger<GetColoresFilamentoQueryHandler> _logger;


        public Task<Result<List<CatalogoDto>>> Handle(GetColoresFilamentoQuery request, CancellationToken cancellationToken)
        {
            var coloresFilamento = ColorFilamentoCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(Result.Success(coloresFilamento));
        }
    }
}