using Domain.Common;

namespace Application.Errors
{
    public static class ProductoErrors
    {
        public static Error NotFound(int id) =>
            Error.NotFound("Producto.NotFound", $"No se encontró el producto con ID {id}.");

        public static Error Deleted(int id) =>
            Error.NotFound("Producto.Deleted", $"El producto con ID {id} ha sido eliminado.");

        public static readonly Error AddFailed =
            Error.Failure("Producto.AddFailed", "Ocurrió un error al intentar agregar el producto.");

        public static Error ColeccionNotFound(int id) =>
            Error.NotFound("Producto.ColeccionNotFound", $"No se encontró la colección con ID {id}.");

        public static Error PublicacionNotFound(int id) =>
            Error.NotFound("Producto.PublicacionNotFound", $"No se encontró ninguna publicación asociada al producto {id}");
    }
}