using Application.Common;
using Application.Common.Dtos;
using Application.Features.Productos.Dtos;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Productos.Queries.GetProductos
{
    public class GetProductosQueryHandler
        : IRequestHandler<GetProductosQuery, Result<BasePagedDto<ProductoBaseDto>>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<GetProductosQueryHandler> _logger;

        public GetProductosQueryHandler(
            IProductoRepository productoRepository,
            ILogger<GetProductosQueryHandler> logger)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<BasePagedDto<ProductoBaseDto>>> Handle(
            GetProductosQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando obtención de productos.");

            var filters = FilterEncoder.Decode<GetProductosFilters>(request.Filters);

            var query = _productoRepository
                .QueryAsNoTracking()
                .Where(p => !p.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Nombre.ToLower().Contains(term) ||
                    p.AutorNombre.ToLower().Contains(term));
            }

            if (filters is not null)
            {
                if (filters.ColeccionId.HasValue)
                    query = query.Where(p => p.ColeccionId == filters.ColeccionId.Value);

                if (filters.IsDeleted.HasValue)
                    query = query.Where(p => p.IsDeleted == filters.IsDeleted.Value);
            }

            query = request.SortBy?.ToLower() switch
            {
                "nombre" => request.SortDescending
                    ? query.OrderByDescending(p => p.Nombre)
                    : query.OrderBy(p => p.Nombre),

                "fecha" => request.SortDescending
                    ? query.OrderByDescending(p => p.FechaLanzamiento)
                    : query.OrderBy(p => p.FechaLanzamiento),

                "autor" => request.SortDescending
                    ? query.OrderByDescending(p => p.AutorNombre)
                    : query.OrderBy(p => p.AutorNombre),

                _ => query.OrderByDescending(p => p.ProductoId)
            };

            var totalItems = await query.CountAsync(cancellationToken);

            if (request.Skip.HasValue)
                query = query.Skip(request.Skip.Value);

            if (request.Take.HasValue)
                query = query.Take(request.Take.Value);

            var items = await query
                .ProjectToType<ProductoBaseDto>()
                .ToListAsync(cancellationToken);

            return Result.Success(new BasePagedDto<ProductoBaseDto>(
                items,
                totalItems,
                request.PageNumber,
                request.PageSize)
            );
        }
    }
}