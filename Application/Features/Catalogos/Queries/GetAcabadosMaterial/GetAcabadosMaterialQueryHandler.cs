using Application.Features.Catalogos.Dtos;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Catalogos.Queries.GetAcabadosMaterial
{
    public class GetAcabadosMaterialQueryHandler : IRequestHandler<GetAcabadosMaterialQuery, Result<List<CatalogoDto>>>
    {
        private readonly ILogger<GetAcabadosMaterialQueryHandler> _logger;

        public Task<Result<List<CatalogoDto>>> Handle(GetAcabadosMaterialQuery request, CancellationToken cancellationToken)
        {
            var acabadosMaterial = AcabadoMaterialCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(Result.Success(acabadosMaterial));
        }
    }
}