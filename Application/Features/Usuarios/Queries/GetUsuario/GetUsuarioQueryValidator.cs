using Application.Features.Usuarios.Queries.GetUsuario;
using FluentValidation;

public class GetUsuarioQueryValidator : AbstractValidator<GetUsuarioQuery>
{
    public GetUsuarioQueryValidator()
    {
        RuleFor(q => q)
            .Must(q => q.UsuarioId.HasValue || !string.IsNullOrEmpty(q.ExternalId))
            .WithMessage("Es necesario proporcionar UsuarioId o ExternalId.");

        RuleFor(q => q)
            .Must(q => !(q.UsuarioId.HasValue && !string.IsNullOrEmpty(q.ExternalId)))
            .WithMessage("No es posible enviar UsuarioId y ExternalId al mismo tiempo.");
    }
}