using Domain.Common;
using Domain.Entities.Productos;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Features.Productos.Errors;

namespace Application.Features.Productos.Commands.AddProducto
{
    public class AddProductoCommandHandler : IRequestHandler<AddProductoCommand, Result<int>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IColeccionRepository _coleccionRepository;
        private readonly ILogger<AddProductoCommandHandler> _logger;

        public AddProductoCommandHandler(
            IProductoRepository productoRepository,
            IColeccionRepository coleccionRepository,
            ILogger<AddProductoCommandHandler> logger)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _coleccionRepository = coleccionRepository ?? throw new ArgumentNullException(nameof(coleccionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<int>> Handle(
            AddProductoCommand command,
            CancellationToken cancellationToken)
        {
            var nuevoProducto = new Producto
            {
                Nombre = command.NombreProducto,
                Descripcion = command.DescripcionProducto,
                EscalaBase = command.EscalaBase,
                CostoProduccionBase = command.CostoProduccionBase,
                FilamentoUsoBase = command.FilamentoUsoBase,
                AutorNombre = command.AutorNombre,
                FechaLanzamiento = command.FechaLanzamiento
            };

            if (command.ColeccionId.HasValue)
            {
                var coleccion = await _coleccionRepository.GetByIdAsync(command.ColeccionId.Value, cancellationToken);

                if (coleccion is null)
                {
                    _logger.LogWarning("Colección con ID {ColeccionId} no encontrada.", command.ColeccionId.Value);
                    return Result.Failure<int>(ProductoErrors.ColeccionNotFound(command.ColeccionId.Value));
                }

                nuevoProducto.AutorNombre = coleccion.AutorNombre;
            }

            await _productoRepository.AddAsync(nuevoProducto, cancellationToken);

            return Result.Success<int>(nuevoProducto.ProductoId);
        }
    }
}