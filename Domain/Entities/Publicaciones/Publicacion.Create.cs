
namespace Domain.Entities.Publicaciones
{
    public partial class Publicacion
    {
        public static Publicacion NewBorrador(int productoId, string titulo, string descripcion, string estadoPublicacionCodigo, bool destacado, string slug)
            => new()
            {
                ProductoId = productoId,
                Titulo = titulo,
                Descripcion = descripcion,
                EstadoPublicacionCodigo = estadoPublicacionCodigo,
                Destacado = destacado,
                Slug = slug
            };

        public static Publicacion NewPublicacion(int productoId, string titulo, string descripcion, string estadoPublicacionCodigo, bool destacado, DateTime fechaPublicacion, string slug)
            => new()
            {
                ProductoId = productoId,
                Titulo = titulo,
                Descripcion = descripcion,
                EstadoPublicacionCodigo = estadoPublicacionCodigo,
                Destacado = destacado,
                FechaPublicacion = fechaPublicacion,
                Slug = slug
            };
    }
}