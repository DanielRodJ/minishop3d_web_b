
namespace Domain.Entities.Productos
{
    public partial class Producto
    {
        public void Update(string nombre, string descripcion, DateOnly fechaLanzmaiento, string? autorNombre, int? coleccionId)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaLanzamiento = fechaLanzmaiento;
            AutorNombre = autorNombre;
            ColeccionId = coleccionId;
        }

        public void AddPresentacion(int productoId, int filamentoId,
            string escalaCodigo, decimal dimensionX, decimal dimensionY, decimal dimensionZ,
            int tiempoImpresionMinutos, decimal cantidadGramosFilamentoUso, string estadoProductoPresentacionCodigo, int stock, decimal precioVenta, decimal costoProduccionAdiconal)
        {
            ProductoPresentaciones ??= [];

            var nuevoProductoPresentacion = ProductoPresentacion.New(
                productoId,
                filamentoId,
                escalaCodigo,
                dimensionX,
                dimensionY,
                dimensionZ,
                tiempoImpresionMinutos,
                cantidadGramosFilamentoUso,
                estadoProductoPresentacionCodigo,
                stock,
                precioVenta,
                costoProduccionAdiconal
            );

            ProductoPresentaciones.Add(nuevoProductoPresentacion);
        }
    }
}