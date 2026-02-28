using Application.Common.Dtos;
using Application.Common.Queries;
using Application.Features.Productos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Productos.Queries.GetProductos
{
    public class GetProductosQuery : BasePagedQuery, IRequest<Result<BasePagedDto<ProductoBaseDto>>>
    {
        public GetProductosQuery(
            int? pageNumber,
            int? pageSize,
            string? searchTerm,
            string? filterBy,
            string? sortBy,
            bool? sortDescending)
            : base(pageNumber, pageSize, searchTerm, filterBy, sortBy, sortDescending)
        {
        }
    }
}