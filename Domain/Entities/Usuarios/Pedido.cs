
namespace Domain.Entities.Usuarios
{
    public class Pedido
    {
        public long PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
