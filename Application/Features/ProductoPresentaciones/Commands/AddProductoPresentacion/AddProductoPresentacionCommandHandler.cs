using Application.Errors;
using Domain.Common;
using Domain.Entities.Productos;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ProductoPresentaciones.Commands.AddProductoPresentacion
{
    public class AddProductoPresentacionCommandHandler : IRequestHandler<AddProductoPresentacionCommand, Result<long>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoPresentacionRepository _productoPresentacionRepository;
        private readonly IFilamentoRepository _filamentoRepository;
        private readonly ILogger<AddProductoPresentacionCommandHandler> _logger;

        public AddProductoPresentacionCommandHandler(
            IProductoRepository productoRepository,
            IProductoPresentacionRepository productoPresentacionRepository,
            IFilamentoRepository filamentoRepository,
            ILogger<AddProductoPresentacionCommandHandler> logger)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _productoPresentacionRepository = productoPresentacionRepository ?? throw new ArgumentNullException(nameof(productoPresentacionRepository));
            _filamentoRepository = filamentoRepository ?? throw new ArgumentNullException(nameof(filamentoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<long>> Handle(AddProductoPresentacionCommand command, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(command.ProductoId, cancellationToken);

            if (producto is null)
            {
                _logger.LogWarning("Producto con ID {ProductoId} no encontrado.", command.ProductoId);
                return Result.Failure<long>(ProductoErrors.NotFound(command.ProductoId));
            }

            if (producto.IsDeleted)
            {
                _logger.LogWarning("Producto con ID {ProductoId} ha sido eliminado.", command.ProductoId);
                return Result.Failure<long>(ProductoErrors.Deleted(command.ProductoId));
            }

            var filamento = await _filamentoRepository.GetByIdTempAsync(command.FilamentoId, cancellationToken);

            if (filamento is null)
            {
                _logger.LogWarning("Filamento con ID {FilamentoId} no encontrado.", command.FilamentoId);
                return Result.Failure<long>(FilamentoErrors.NotFound(command.FilamentoId));
            }

            var nuevoProductoPresentacion = ProductoPresentacion.New(
                command.ProductoId,
                command.FilamentoId,
                command.EscalaCodigo,
                command.DimensionX,
                command.DimensionY,
                command.DimensionZ,
                command.TiempoImpresionMinutos,
                command.CantidadGramosFilamentoUso,
                command.EstadoProductoPresentacionCodigo,
                command.Stock,
                command.PrecioVenta,
                command.CostoProduccionAdcional
            );

            await _productoPresentacionRepository.AddAsync(nuevoProductoPresentacion, cancellationToken);

            return Result.Success(nuevoProductoPresentacion.ProductoPresentacionId);
        }
    }
}