using Domain.Entities.Productos;
using Mapster;

namespace Application.Features.Filamentos.Dtos
{
    public class FilamentoDto
    {
        public long FilamentoId { get; set; }
        public string Display { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string TipoMaterial { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Acabado { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }

    public class FilamentoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Filamento, FilamentoDto>()
                .Map(dest => dest.FilamentoId, src => src.FilamentoId)
                .Map(dest => dest.Codigo, src => src.Codigo)
                .Map(dest => dest.TipoMaterial, src => src.TipoMaterial)
                .Map(dest => dest.Color, src => src.Color)
                .Map(dest => dest.Acabado, src => src.Acabado)
                .Map(dest => dest.Activo, src => src.Activo);
        }
    }
}