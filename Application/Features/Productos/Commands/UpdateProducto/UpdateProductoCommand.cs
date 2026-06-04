using Domain.Common;
using MediatR;

namespace Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommand : IRequest<Result<bool>>
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string DescripcionProducto { get; set; } = string.Empty;
        public string? AutorNombre { get; set; } = string.Empty;
        public DateOnly FechaLanzamiento { get; set; }
        public int? ColeccionId { get; set; }
    }
}