using Domain.Common;

namespace Domain.Entities.Usuarios
{
    public class Usuario : SoftDeletableEntity
    {
        public int UsuarioId { get; set; }
        public string Uid { get; set; } = string.Empty;
        public string? Nombre { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool EsAdmin { get; set; }
        public virtual ICollection<Pedido>? Pedidos { get; set; }

        private Usuario() { }

        public static Usuario New(string uid, string? nombre, string email, bool esAdmin)
            => new()
            {
                Uid = uid,
                Nombre = nombre,
                Email = email,
                EsAdmin = esAdmin
            };
    }
}