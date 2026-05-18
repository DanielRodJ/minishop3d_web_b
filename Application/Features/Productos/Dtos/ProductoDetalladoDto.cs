using Application.Features.ProductoPresentaciones.Dtos;
using Domain.Entities.Productos;
using Mapster;

namespace Application.Features.Productos.Dtos
{
    public class ProductoDetalladoDto
    {
        public int ProductoId { get; set; }
        public int? ColeccionId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string DescripcionProducto { get; set; } = string.Empty;
        public string? AutorNombre { get; set; } = string.Empty;
        public DateOnly FechaLanzamiento { get; set; }
        public List<ProductoPresentacionDto>? ProductoPresentaciones { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProductoDelladoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Producto, ProductoDetalladoDto>()
                .Map(dest => dest.ProductoId, src => src.ProductoId)
                .Map(dest => dest.NombreProducto, src => src.Nombre)
                .Map(dest => dest.DescripcionProducto, src => src.Descripcion)
                .Map(dest => dest.AutorNombre, src => src.AutorNombre)
                .Map(dest => dest.FechaLanzamiento, src => src.FechaLanzamiento)
                .Map(dest => dest.ProductoPresentaciones, src => src.ProductoPresentaciones);
        }
    }
}