using Domain.Common;

namespace Application.Errors
{
    public class ProductoPresentacionErrors
    {
        public static Error NotFound(long id) =>
            Error.NotFound("Producto_Presentacion.NotFound", $"No se encontró el producto presentacion con ID {id}.");
    }
}