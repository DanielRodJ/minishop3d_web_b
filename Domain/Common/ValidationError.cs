namespace Domain.Common
{
    public sealed class ValidationError : Error
    {
        public ValidationError(Error[] errors)
            : base(
                "General.Validation",
                "Se produjeron uno o más errores de validación.",
                ErrorType.Validation)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }

        public static ValidationError FromFluentErrors(IEnumerable<string> errorMessages) =>
            new(errorMessages
                .Select(msg => Error.Validation("Validation.Error", msg))
                .ToArray());
    }
}