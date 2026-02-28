
namespace Application.Interfaces
{
    public interface ICurrentUserService
    {
        int? UsuarioId { get; }
        bool EsAdmin { get; }
        string? FirebaseUid { get; }
        string? FirebaseUsername { get; }
        string? FirebaseEmail { get; }
        bool IsAuthenticated { get; }
    }
}