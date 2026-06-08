using Application.Errors;
using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.ProductoPresentaciones.Commands.UpdateProductoPresentacion
{
    public class UpdateProductoPresentacionCommandHandler : IRequestHandler<UpdateProductoPresentacionCommand, Result<bool>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoPresentacionRepository _productoPresentacionRepository;
        private readonly IFilamentoRepository _filamentoRepository;
        private readonly ILogger<UpdateProductoPresentacionCommandHandler> _logger;

        public UpdateProductoPresentacionCommandHandler(
            IProductoRepository productoRepository,
            IProductoPresentacionRepository productoPresentacionRepository,
            IFilamentoRepository filamentoRepository,
            ILogger<UpdateProductoPresentacionCommandHandler> logger
            )
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _productoPresentacionRepository = productoPresentacionRepository ?? throw new ArgumentNullException(nameof(productoPresentacionRepository));
            _filamentoRepository = filamentoRepository ?? throw new ArgumentNullException(nameof(filamentoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<bool>> Handle(UpdateProductoPresentacionCommand command, CancellationToken cancellationToken)
        {

            var filamento = await _filamentoRepository.GetByIdTempAsync(command.FilamentoId, cancellationToken);

            if (filamento is null)
            {
                _logger.LogWarning("Filamento con ID {FilamentoId} no encontrado.", command.FilamentoId);
                return Result.Failure<bool>(FilamentoErrors.NotFound(command.FilamentoId));
            }

            var productoPresentacion = await _productoPresentacionRepository
                .Query()
                .Where(pp => pp.ProductoPresentacionId == command.ProductoPresentacionId)
                .FirstOrDefaultAsync(cancellationToken);

            if (productoPresentacion is null)
            {
                _logger.LogWarning("Producto Presentacion con ID {ProductoPresentacionId} no encontrado.", command.ProductoPresentacionId);
                return Result.Failure<bool>(ProductoPresentacionErrors.NotFound(command.ProductoId));
            }

            productoPresentacion.UpdateProductoPresentacion(
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

            await _productoPresentacionRepository.UpdateAsync(productoPresentacion, cancellationToken);

            return Result.Success(true);
        }
    }
}