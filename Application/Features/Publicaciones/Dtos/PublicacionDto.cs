using Domain.Entities.Publicaciones;
using Mapster;

namespace Application.Features.Publicaciones.Dtos
{
    public class PublicacionDto
    {
        public long PublicacionId { get; set; }
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string EstadoPublicacionCodigo { get; set; } = string.Empty;
        public bool Destacado { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string Slug { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }

    public class PublicacionMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Publicacion, PublicacionDto>()
                .Map(dest => dest.PublicacionId, src => src.PublicacionId)
                .Map(dest => dest.ProductoId, src => src.ProductoId)
                .Map(dest => dest.Titulo, src => src.Titulo)
                .Map(dest => dest.Descripcion, src => src.Descripcion)
                .Map(dest => dest.EstadoPublicacionCodigo, src => src.EstadoPublicacionCodigo)
                .Map(dest => dest.Destacado, src => src.Destacado)
                .Map(dest => dest.FechaPublicacion, src => src.FechaPublicacion)
                .Map(dest => dest.Slug, src => src.Slug)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted);
        }
    }
}