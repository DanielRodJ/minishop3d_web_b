using Application.Features.Catalogos.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEscalas
{
    public class GetEscalasQueryHandler
        : IRequestHandler<GetEscalasQuery, List<CatalogoDto>>
    {
        public Task<List<CatalogoDto>> Handle(
            GetEscalasQuery request,
            CancellationToken cancellationToken
            )
        {
            var escalas = EscalaCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(escalas);
        }
    }
}