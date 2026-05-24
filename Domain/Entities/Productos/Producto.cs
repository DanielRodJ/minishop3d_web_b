using Domain.Common;

namespace Domain.Entities.Productos
{
    public partial class Producto : SoftDeletableEntity
    {
        public Producto() { }

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string? AutorNombre { get; set; } = string.Empty;
        public DateOnly FechaLanzamiento { get; set; }
        public int? ColeccionId { get; set; }
        public virtual Coleccion? Coleccion { get; set; }
        public virtual ICollection<ProductoPresentacion> ProductoPresentaciones { get; set; } = [];
    }
}