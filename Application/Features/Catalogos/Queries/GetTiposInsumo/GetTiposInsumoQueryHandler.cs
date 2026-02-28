using Application.Features.Catalogos.Dtos;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Catalogos.Queries.GetTiposInsumo
{
    public class GetTiposInsumoQueryHandler : IRequestHandler<GetTiposInsumoQuery, Result<List<CatalogoDto>>>
    {
        private readonly ILogger<GetTiposInsumoQueryHandler> _logger;

        public Task<Result<List<CatalogoDto>>> Handle(GetTiposInsumoQuery request, CancellationToken cancellationToken)
        {
            var tiposInsumo = TipoInsumoCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(Result.Success(tiposInsumo));
        }
    }
}