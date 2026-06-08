using Application.Common.Dtos;
using Application.Common.Queries;
using Application.Features.ProductoPresentaciones.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Productos.Queries.GetProductoPresentaciones
{
    public class GetProductoPresentacionesQuery : BasePagedQuery, IRequest<Result<BasePagedDto<ProductoPresentacionDto>>>
    {
        public int ProductoId { get; set; }

        public GetProductoPresentacionesQuery(
            int productoId,
            int? pageNumber,
            int? pageSize,
            string? searchTerm,
            string? filterBy,
            string? sortBy,
            bool? sortDescending)
            : base(pageNumber, pageSize, searchTerm, filterBy, sortBy, sortDescending)
        {
            ProductoId = productoId;
        }
    }
}