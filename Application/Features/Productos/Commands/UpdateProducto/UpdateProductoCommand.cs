namespace Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommand
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string DescripcionProducto { get; set; } = string.Empty;
        public string EscalaBase { get; set; } = string.Empty;
        public decimal CostoProduccionBase { get; set; }
        public decimal FilamentoUsoBase { get; set; }
        public string? AutorNombre { get; set; } = string.Empty;
        public DateOnly FechaLanzamiento { get; set; }

        public int? ColeccionId { get; set; }
    }
}