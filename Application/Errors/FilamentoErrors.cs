using Domain.Common;

namespace Application.Errors
{
    public class FilamentoErrors
    {
        public static Error NotFound(long id) =>
            Error.NotFound("Filamento.NotFound", $"No se encontró el filamento con ID {id}.");
    }
}