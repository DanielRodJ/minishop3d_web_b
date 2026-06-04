using Application.Errors;
using Application.Features.Productos.Commands.AddProducto;
using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, Result<bool>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IColeccionRepository _coleccionRepository;
        private readonly ILogger<AddProductoCommandHandler> _logger;

        public UpdateProductoCommandHandler(
            IProductoRepository productoRepository,
            IColeccionRepository coleccionRepository,
            ILogger<AddProductoCommandHandler> logger)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _coleccionRepository = coleccionRepository ?? throw new ArgumentNullException(nameof(coleccionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<bool>> Handle(UpdateProductoCommand command, CancellationToken cancellationToken)
        {

            var producto = await _productoRepository
                .Query()
                .Where(p => p.ProductoId == command.ProductoId
                    && !p.IsDeleted
                ).FirstOrDefaultAsync(cancellationToken);

            if (producto is null)
            {
                _logger.LogWarning("Producto con ID {ProductoId} no encontrado.", command.ProductoId);
                return Result.Failure<bool>(ProductoErrors.NotFound(command.ProductoId));
            }

            if (command.ColeccionId.HasValue)
            {
                var coleccion = await _coleccionRepository.GetByIdAsync(command.ColeccionId.Value, cancellationToken);

                if (coleccion is null)
                {
                    _logger.LogWarning("Colección con ID {ColeccionId} no encontrada.", command.ColeccionId.Value);
                    return Result.Failure<bool>(ProductoErrors.ColeccionNotFound(command.ColeccionId.Value));
                }

                command.AutorNombre = coleccion.AutorNombre;
            }

            producto.Update(
                command.NombreProducto,
                command.DescripcionProducto,
                command.FechaLanzamiento,
                command.AutorNombre,
                command.ColeccionId
            );

            await _productoRepository.UpdateAsync(producto, cancellationToken);

            return Result.Success(true);
        }
    }
}