
namespace Domain.Entities.Productos
{
    public partial class ProductoPresentacion
    {
        public static ProductoPresentacion New(int productoId, long filamentoId, string escalaCodigo, decimal dimensionX, decimal dimensionY, decimal dimensionZ,
            int tiempoImpresionMinutos, decimal cantidadGramosFilamentoUso, string estadoProductoPresentacionCodigo, int stock, decimal precioVenta, decimal costoProduccionAdiconal)
            => new()
            {
                ProductoId = productoId,
                FilamentoId = filamentoId,
                EscalaCodigo = escalaCodigo,
                DimensionX = dimensionX,
                DimensionY = dimensionY,
                DimensionZ = dimensionZ,
                TiempoImpresionMinutos = tiempoImpresionMinutos,
                CantidadGramosFilamentoUso = cantidadGramosFilamentoUso,
                EstadoProductoPresentacionCodigo = estadoProductoPresentacionCodigo,
                Stock = stock,
                PrecioVenta = precioVenta,
                CostoProduccionAdicional = costoProduccionAdiconal
            };
    }
}