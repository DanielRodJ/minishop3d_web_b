using Application.Features.Catalogos.Dtos;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Catalogos.Queries.GetEscalas
{
    public class GetEscalasQueryHandler : IRequestHandler<GetEscalasQuery, Result<List<CatalogoDto>>>
    {
        private readonly ILogger<GetEscalasQueryHandler> _logger;

        public Task<Result<List<CatalogoDto>>> Handle(GetEscalasQuery request, CancellationToken cancellationToken)
        {
            var escalas = EscalaCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(Result.Success(escalas));
        }
    }
}