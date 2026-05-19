using Domain.Enums;
using FluentValidation;

namespace Application.Features.ProductoPresentaciones.Commands.CalculateProductoPresentacion
{
    public class CalculateProductoPresentacionCommandValidator : AbstractValidator<CalculateProductoPresentacionCommand>
    {
        public CalculateProductoPresentacionCommandValidator()
        {
            List<string> escalasValidas = new()
            {
                EscalaCatalogo.Heroic28mm.Codigo,
                EscalaCatalogo.Display75mm.Codigo,
            };

            RuleFor(cmd => cmd.FilamentoId)
                .GreaterThan(0)
                .WithMessage("El ID del filamento debe ser mayor que 0.");

            RuleFor(cmd => cmd.EscalaCodigo)
                .NotEmpty()
                .WithMessage("La escala de la variante es obligatoria.")
                .Must(escalasValidas.Contains)
                .WithMessage("La escala seleccionada no es válida.");

            RuleFor(cmd => cmd.TiempoImpresionMinutos)
                .GreaterThan(0)
                .WithMessage("El tiempo de impresión debe ser mayor que 0.");

            RuleFor(cmd => cmd.CantidadGramosFilamentoUso)
                .GreaterThan(0)
                .WithMessage("La cantidad de filamento debe ser mayor que 0.");

            RuleFor(cmd => cmd.CostoProduccionAdicional)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El costo de producción adicional no puede ser negativo.");
        }
    }
}