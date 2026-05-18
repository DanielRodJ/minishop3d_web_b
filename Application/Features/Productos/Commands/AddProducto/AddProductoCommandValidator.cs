using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Productos.Commands.AddProducto
{
    public class AddProductoCommandValidator : AbstractValidator<AddProductoCommand>
    {
        public AddProductoCommandValidator(IDateTimeService dateTimeService)
        {
            RuleFor(cmd => cmd.NombreProducto)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del producto no puede exceder los 100 caracteres.");

            RuleFor(cmd => cmd.DescripcionProducto)
                .NotEmpty().WithMessage("La descripción del producto es obligatoria.");

            RuleFor(cmd => cmd.AutorNombre)
                .MaximumLength(100).WithMessage("El nombre del autor no puede exceder los 100 caracteres.");

            RuleFor(cmd => cmd.FechaLanzamiento)
                .LessThanOrEqualTo(dateTimeService.Today)
                .WithMessage("La fecha de lanzamiento no puede ser futura.");

            RuleFor(cmd => cmd.ColeccionId)
                .GreaterThan(0)
                .When(cmd => cmd.ColeccionId.HasValue)
                .WithMessage("La colección debe ser mayor que 0.");
        }
    }
}