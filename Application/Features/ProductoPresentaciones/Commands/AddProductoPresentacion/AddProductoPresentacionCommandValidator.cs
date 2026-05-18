using Domain.Enums;
using FluentValidation;

namespace Application.Features.ProductoPresentaciones.Commands.AddProductoPresentacion
{
    public class AddProductoPresentacionCommandValidator : AbstractValidator<AddProductoPresentacionCommand>
    {
        public AddProductoPresentacionCommandValidator()
        {
            List<string> escalasValidas = new List<string>()
            {
                EscalaCatalogo.Heroic28mm.Codigo,
                EscalaCatalogo.Display75mm.Codigo,
            };

            List<string> estadosValidos = new List<string>()
            {
                EstadoProductoCatalogo.Disponible.Codigo,
                EstadoProductoCatalogo.Agotado.Codigo,
                EstadoProductoCatalogo.InactivoTemporal.Codigo,
                EstadoProductoCatalogo.NoDisponible.Codigo,
            };

            RuleFor(cmd => cmd.ProductoId)
                .GreaterThan(0)
                .WithMessage("El ID del producto debe ser mayor que 0.");

            RuleFor(cmd => cmd.FilamentoId)
                .GreaterThan(0)
                .WithMessage("El ID del filamento debe ser mayor que 0.");

            RuleFor(cmd => cmd.EscalaCodigo)
                .NotEmpty()
                .WithMessage("La escala de la variante es obligatoria.")
                .Must(escalasValidas.Contains)
                .WithMessage("La escala seleccionada no es válida.");

            RuleFor(cmd => cmd.DimensionX)
                .NotEmpty().WithMessage("La dimensión en X es obligatoria.");

            RuleFor(cmd => cmd.DimensionY)
                .NotEmpty().WithMessage("La dimensión en Y es obligatoria.");

            RuleFor(cmd => cmd.DimensionZ)
                .NotEmpty().WithMessage("La dimensión en Z es obligatoria.");

            RuleFor(cmd => cmd.TiempoImpresionMinutos)
                .GreaterThan(0)
                .WithMessage("El tiempo de impresión debe ser mayor que 0.");

            RuleFor(cmd => cmd.CantidadGramosFilamentoUso)
                .GreaterThan(0)
                .WithMessage("La cantidad de filamento debe ser mayor que 0.");

            RuleFor(cmd => cmd.EstadoProductoPresentacionCodigo)
                .NotEmpty()
                .WithMessage("El estado de la variante es obligatorio.")
                .Must(estadosValidos.Contains)
                .WithMessage("El estado seleccionado no es válido.");
        }
    }
}
