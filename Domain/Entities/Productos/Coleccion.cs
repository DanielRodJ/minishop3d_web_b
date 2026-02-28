namespace Domain.Entities.Productos
{
    public partial class Coleccion
    {
        public int ColeccionId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string? AutorNombre { get; set; } = string.Empty;
        public DateOnly FechaLanzamiento { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}