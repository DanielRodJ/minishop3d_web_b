using Domain.Entities.Productos;
using Mapster;

namespace Application.Features.Productos.Dtos
{
    public class ColeccionDto
    {
        public int ColeccionId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class ColeccionMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Coleccion, ColeccionDto>()
                .Map(dest => dest.ColeccionId, src => src.ColeccionId)
                .Map(dest => dest.Nombre, src => src.Nombre);
        }
    }
}