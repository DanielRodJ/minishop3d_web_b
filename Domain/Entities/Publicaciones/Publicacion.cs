
using Domain.Common;

namespace Domain.Entities.Publicaciones
{
    public partial class Publicacion : SoftDeletableEntity
    {
        private Publicacion() { }

        public long PublicacionId { get; set; }
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string EstadoPublicacionCodigo { get; set; } = string.Empty;
        public bool Destacado { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string Slug { get; set; } = string.Empty;
    }
}