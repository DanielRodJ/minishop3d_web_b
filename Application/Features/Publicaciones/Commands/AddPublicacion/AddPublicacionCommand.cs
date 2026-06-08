using Domain.Common;
using MediatR;

namespace Application.Features.Publicaciones.Commands.AddPublicacion
{
    public class AddPublicacionCommand : IRequest<Result<long>>
    {
        public string TituloPublicacion { get; set; } = string.Empty;
        public string DescripcionPublicacion { get; set; } = string.Empty;
        public int ProductoId { get; set; }
        public string EstadoPublicacionCodigo { get; set; } = string.Empty;
        public bool Destacado { get; set; }
    }
}