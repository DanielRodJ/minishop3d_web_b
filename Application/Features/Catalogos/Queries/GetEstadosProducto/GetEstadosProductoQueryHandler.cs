using Application.Features.Catalogos.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEstadosProducto
{
    public class GetEstadosProductoQueryHandler
        : IRequestHandler<GetEstadosProductoQuery, List<CatalogoDto>>
    {
        public Task<List<CatalogoDto>> Handle(
            GetEstadosProductoQuery request,
            CancellationToken cancellationToken
            )
        {
            var estadosProducto = EstadoProductoCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(estadosProducto);
        }
    }
}