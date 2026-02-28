
namespace Domain.Common
{
    public class Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error Unexpected = new("General.Unexpected", "Ocurrió un error inesperado.", ErrorType.Unexpected);

        protected Error(string codigo, string mensaje, ErrorType tipo)
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Tipo = tipo;
        }

        public string Codigo { get; }
        public string Mensaje { get; }
        public ErrorType Tipo { get; }

        public static Error NotFound(string code, string message) =>
            new(code, message, ErrorType.NotFound);

        public static Error Validation(string code, string message) =>
            new(code, message, ErrorType.Validation);

        public static Error Conflict(string code, string message) =>
            new(code, message, ErrorType.Conflict);

        public static Error Unauthorized(string code, string message) =>
            new(code, message, ErrorType.Unauthorized);

        public static Error Failure(string code, string message) =>
            new(code, message, ErrorType.Failure);
    }

    public enum ErrorType
    {
        Failure,
        Validation,
        NotFound,
        Conflict,
        Unauthorized,
        Unexpected
    }
}