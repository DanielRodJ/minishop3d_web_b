using Domain.Enums;
using FluentValidation;

namespace Application.Features.Publicaciones.UpdatePublicacionEstado
{
    public class UpdatePublicacionEstadoCommandValidator : AbstractValidator<UpdatePublicacionEstadoCommand>
    {
        public UpdatePublicacionEstadoCommandValidator() {

            List<string> estadosValidos = new List<string> {
                EstadoPublicacionCatalogo.Activa.Codigo,
                EstadoPublicacionCatalogo.Inactiva.Codigo,
                EstadoPublicacionCatalogo.Borrador.Codigo
            };

            RuleFor(cmd => cmd.ProductoId)
                .GreaterThan(0)
                .WithMessage("El ID del producto debe ser mayor que 0.");
            
            RuleFor(cmd => cmd.EstadoPublicacionCodigo)
                .NotEmpty()
                .WithMessage("El nuevo estado de la publicaciónn es obligatorio.");
        }
    }
}