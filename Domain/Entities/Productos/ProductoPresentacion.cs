namespace Domain.Entities.Productos
{
    public partial class ProductoPresentacion
    {
        public long ProductoPresentacionId { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto? Producto { get; set; }
        public string EscalaCodigo { get; set; } = string.Empty;
        public string TipoMaterialCodigo { get; set; } = string.Empty;
        public string AcabadoMaterialCodigo { get; set; } = string.Empty;
        public string ColorFilamentoCodigo { get; set; } = string.Empty;
        public string ProductoEstadoCodigo { get; set; } = string.Empty;
        public decimal CostoProduccionAdicional { get; set; }
        public decimal FilamentoUsoAdicional { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
    }
}
