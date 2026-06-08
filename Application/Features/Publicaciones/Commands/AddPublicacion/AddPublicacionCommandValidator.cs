using Domain.Enums;
using FluentValidation;

namespace Application.Features.Publicaciones.Commands.AddPublicacion
{
    public class AddPublicacionCommandValidator : AbstractValidator<AddPublicacionCommand>
    {
        public AddPublicacionCommandValidator()
        {
            List<string> estadosValidos = new List<string> {
                EstadoPublicacionCatalogo.Activa.Codigo,
                EstadoPublicacionCatalogo.Inactiva.Codigo,
                EstadoPublicacionCatalogo.Borrador.Codigo
            };

            RuleFor(cmd => cmd.TituloPublicacion)
                .NotEmpty().WithMessage("El título de la publicación es obligatorio.");

            RuleFor(cmd => cmd.DescripcionPublicacion)
                .NotEmpty().WithMessage("La descripción del producto en publicación es obligatorio.");

            RuleFor(cmd => cmd.EstadoPublicacionCodigo)
                .NotEmpty().WithMessage("El estado actual de la publicación es obligatorio.");

            RuleFor(cmd => cmd.Destacado)
                .NotNull().WithMessage("Es necesario indicar si se trata de una publicación destacada.");

            RuleFor(cmd => cmd.ProductoId)
                .GreaterThan(0).WithMessage("El ID del producto debe ser mayor que 0.");
        }
    }
}