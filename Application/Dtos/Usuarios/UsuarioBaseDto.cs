
namespace Application.Dtos.Usuarios
{
    public class UsuarioBaseDto
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}