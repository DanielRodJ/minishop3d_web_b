using Domain.Common;

namespace Application.Features.Productos.Errors
{
    public static class ProductoErrors
    {
        public static Error ColeccionNotFound(int id) =>
            Error.NotFound("Producto.ColeccionNotFound", $"No se encontró la colección con ID {id}.");

        public static readonly Error AddFailed =
            Error.Failure("Producto.AddFailed", "Ocurrió un error al intentar agregar el producto.");
    }
}