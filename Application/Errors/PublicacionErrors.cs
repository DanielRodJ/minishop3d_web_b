using Domain.Common;

namespace Application.Errors
{
    public class PublicacionErrors
    {
        public static Error NotFound(int id) =>
            Error.NotFound("Producto.NotFound", $"No se encontró la publicación con ID {id}.");

        public static Error PublicacionActivaExistente(int productoId) =>
            Error.Conflict("Publicacion.ActivaExistente", $"El producto {productoId} ya tiene una publicación activa.");
    }
}