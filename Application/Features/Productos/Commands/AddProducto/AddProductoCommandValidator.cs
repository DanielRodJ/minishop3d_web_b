using FluentValidation;

namespace Application.Features.Productos.Commands.AddProducto
{
    public class AddProductoCommandValidator : AbstractValidator<AddProductoCommand>
    {
        public AddProductoCommandValidator()
        {
            RuleFor(x => x.NombreProducto)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del producto no puede exceder los 100 caracteres.");

            RuleFor(x => x.DescripcionProducto)
                .NotEmpty().WithMessage("La descripción del producto es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción del producto no puede exceder los 500 caracteres.");

            RuleFor(x => x.EscalaBase)
                .NotEmpty().WithMessage("La escala base es obligatoria.")
                .MaximumLength(50).WithMessage("La escala base no puede exceder los 50 caracteres.");

            RuleFor(x => x.CostoProduccionBase)
                .GreaterThan(0).WithMessage("El costo de producción base debe ser mayor que cero.");

            RuleFor(x => x.FilamentoUsoBase)
                .GreaterThan(0).WithMessage("El filamento de uso base debe ser mayor que cero.");

            RuleFor(x => x.AutorNombre)
                .MaximumLength(100).WithMessage("El nombre del autor no puede exceder los 100 caracteres.");

            RuleFor(x => x.FechaLanzamiento)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha de lanzamiento no puede ser futura.");
        }
    }
}