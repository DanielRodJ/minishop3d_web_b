using Application.Errors;
using Application.Features.Productos.Dtos;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Productos.Queries.GetProducto
{
    public class GetProductoQueryHandler : IRequestHandler<GetProductoQuery, Result<ProductoDetalladoDto>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<GetProductoQueryHandler> _logger;

        public GetProductoQueryHandler(
            IProductoRepository productoRepository,
            ILogger<GetProductoQueryHandler> logger)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<ProductoDetalladoDto>> Handle(
            GetProductoQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando obtención de producto con ID {}", request.ProductoId);

            var producto = await _productoRepository
                .QueryAsNoTracking()
                .Where(p => p.ProductoId == request.ProductoId)
                .Include(p => p.ProductoPresentaciones)
                .ThenInclude(pp => pp.Filamento)
                .FirstOrDefaultAsync(cancellationToken);

            if (producto is null)
                return Result.Failure<ProductoDetalladoDto>(ProductoErrors.NotFound(request.ProductoId));

            if (producto.IsDeleted)
                return Result.Failure<ProductoDetalladoDto>(ProductoErrors.Deleted(request.ProductoId));

            var productoDetalladoDto = producto.Adapt<ProductoDetalladoDto>();

            return Result.Success(productoDetalladoDto);
        }
    }
}