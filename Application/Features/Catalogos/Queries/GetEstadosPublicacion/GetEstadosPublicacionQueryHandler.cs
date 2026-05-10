using Application.Features.Catalogos.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEstadosPublicacion
{
    public class GetEstadosPublicacionQueryHandler
        : IRequestHandler<GetEstadosPublicacionQuery, List<CatalogoDto>>
    {
        public Task<List<CatalogoDto>> Handle(
            GetEstadosPublicacionQuery request,
            CancellationToken cancellationToken
            )
        {
            var estadosPublicacion = EstadoPublicacionCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(estadosPublicacion);
        }
    }
}