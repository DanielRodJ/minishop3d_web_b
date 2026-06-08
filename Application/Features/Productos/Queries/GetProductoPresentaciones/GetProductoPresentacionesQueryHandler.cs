using Application.Common;
using Application.Common.Dtos;
using Application.Features.ProductoPresentaciones.Dtos;
using Application.Features.Productos.Queries.GetProductos;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Productos.Queries.GetProductoPresentaciones
{
    public class GetProductoPresentacionesQueryHandler : IRequestHandler<GetProductoPresentacionesQuery, Result<BasePagedDto<ProductoPresentacionDto>>>
    {
        private readonly IProductoPresentacionRepository _productoPresentacionRepository;
        private readonly ILogger<GetProductoPresentacionesQueryHandler> _logger;

        public GetProductoPresentacionesQueryHandler(
            IProductoPresentacionRepository productoPresentacionRepository,
            ILogger<GetProductoPresentacionesQueryHandler> logger)
        {
            _productoPresentacionRepository = productoPresentacionRepository ?? throw new ArgumentNullException(nameof(productoPresentacionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<BasePagedDto<ProductoPresentacionDto>>> Handle(GetProductoPresentacionesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando obtención de presentaciones para producto {ProductoId}.", request.ProductoId);

            var filters = FilterEncoder.Decode<GetProductosFilters>(request.Filters);

            var productoPresentacionesQuery = _productoPresentacionRepository
                .QueryAsNoTracking()
                .Where(pp => pp.ProductoId == request.ProductoId 
                    && !pp.IsDeleted
                );

            if (filters is not null)
            {

            }

            productoPresentacionesQuery = request.SortBy?.ToLower() switch
            {
                "productoId" => request.SortDescending
                    ? productoPresentacionesQuery.OrderByDescending(pp => pp.ProductoId)
                    : productoPresentacionesQuery.OrderBy(pp => pp.ProductoId),

                _ => productoPresentacionesQuery.OrderByDescending(p => p.ProductoId)
            };

            var totalItems = await productoPresentacionesQuery.CountAsync(cancellationToken);

            if (request.Skip.HasValue)
                productoPresentacionesQuery = productoPresentacionesQuery.Skip(request.Skip.Value);

            if (request.Take.HasValue)
                productoPresentacionesQuery = productoPresentacionesQuery.Take(request.Take.Value);

            var items = await productoPresentacionesQuery
                .ProjectToType<ProductoPresentacionDto>()
                .ToListAsync(cancellationToken);

            return Result.Success(new BasePagedDto<ProductoPresentacionDto>(
                items,
                totalItems,
                request.PageNumber,
                request.PageSize)
            );
        }
    }
}