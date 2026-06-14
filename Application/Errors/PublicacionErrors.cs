using Domain.Common;

namespace Application.Errors
{
    public class PublicacionErrors
    {
        public static Error NotFound(long id) =>
            Error.NotFound("Publicacion.NotFound", $"No se encontró la publicación con ID {id}.");

        public static Error Deleted(long id) =>
            Error.NotFound("Publicacion.Deleted", $"La publicación con ID {id} ha sido eliminado.");

        public static Error PublicacionActivaExistente(int productoId) =>
            Error.Conflict("Publicacion.ActivaExistente", $"El producto {productoId} ya tiene una publicación activa.");
    }
}