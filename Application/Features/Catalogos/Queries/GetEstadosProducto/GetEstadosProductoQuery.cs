using Application.Features.Catalogos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEstadosProducto
{
    public class GetEstadosProductoQuery : IRequest<Result<List<CatalogoDto>>>
    {
    }
}