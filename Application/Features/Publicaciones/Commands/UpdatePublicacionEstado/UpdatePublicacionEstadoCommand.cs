using Application.Features.Productos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Publicaciones.Commands.UpdatePublicacionEstado
{
    public class UpdatePublicacionEstadoCommand : IRequest<Result<ProductoBaseDto>>
    {
        public int ProductoId { get; set; }
        public string EstadoPublicacionCodigo { get; set; } = string.Empty;
    }
}
