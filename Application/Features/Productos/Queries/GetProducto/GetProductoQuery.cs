using Application.Features.Productos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Productos.Queries.GetProducto
{
    public class GetProductoQuery : IRequest<Result<ProductoDetalladoDto>>
    {
        public int ProductoId { get; }

        public GetProductoQuery(int productoId)
        {
            ProductoId = productoId;
        }
    }
}