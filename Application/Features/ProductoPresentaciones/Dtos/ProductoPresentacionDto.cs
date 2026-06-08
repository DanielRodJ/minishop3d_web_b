using Application.Features.Filamentos.Dtos;
using Domain.Entities.Productos;
using Mapster;

namespace Application.Features.ProductoPresentaciones.Dtos
{
    public class ProductoPresentacionDto
    {
        public long ProductoPresentacionId { get; set; }
        public int ProductoId { get; set; }
        public long FilamentoId { get; set; }
        public FilamentoDto? Filamento { get; set; }
        public string EscalaCodigo { get; set; } = string.Empty;
        public decimal DimensionX { get; set; }
        public decimal DimensionY { get; set; }
        public decimal DimensionZ { get; set; }
        public int TiempoImpresionMinutos { get; set; }
        public decimal CantidadGramosFilamentoUso { get; set; }
        public string EstadoProductoPresentacionCodigo { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal CostoProduccionAdicional { get; set; }
        public decimal PrecioVenta { get; set; }

    }

    public class ProductoPresentacionMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductoPresentacion, ProductoPresentacionDto>()
                .Map(dest => dest.ProductoPresentacionId, src => src.ProductoPresentacionId)
                .Map(dest => dest.ProductoId, src => src.ProductoId)
                .Map(dest => dest.FilamentoId, src => src.FilamentoId)
                .Map(dest => dest.Filamento, src => src.Filamento)
                .Map(dest => dest.EscalaCodigo, src => src.EscalaCodigo)
                .Map(dest => dest.DimensionX, src => src.DimensionX)
                .Map(dest => dest.DimensionY, src => src.DimensionY)
                .Map(dest => dest.DimensionZ, src => src.DimensionZ)
                .Map(dest => dest.TiempoImpresionMinutos, src => src.TiempoImpresionMinutos)
                .Map(dest => dest.CantidadGramosFilamentoUso, src => src.CantidadGramosFilamentoUso)
                .Map(dest => dest.EstadoProductoPresentacionCodigo, src => src.EstadoProductoPresentacionCodigo)
                .Map(dest => dest.Stock, src => src.Stock)
                .Map(dest => dest.CostoProduccionAdicional, src => src.CostoProduccionAdicional)
                .Map(dest => dest.PrecioVenta, src => src.PrecioVenta);
        }
    }
}