using Domain.Entities.Productos;
using Mapster;

namespace Application.Features.Productos.Dtos
{
    public class ProductoBaseDto
    {
        public int ProductoId { get; set; }
        public int? ColeccionId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? AutorNombre { get; set; } = string.Empty;
        public DateOnly FechaLanzamiento { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProductoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Producto, ProductoBaseDto>()
                .Map(dest => dest.ProductoId, src => src.ProductoId)
                .Map(dest => dest.Nombre, src => src.Nombre)
                .Map(dest => dest.AutorNombre, src => src.AutorNombre)
                .Map(dest => dest.FechaLanzamiento, src => src.FechaLanzamiento);
        }
    }
}