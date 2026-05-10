using Application.Features.Catalogos.Dtos;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEstadosProducto
{
    public class GetEstadosProductoQuery : IRequest<List<CatalogoDto>>;
}