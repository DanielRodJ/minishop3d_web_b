using Domain.Entities.Productos;
using Domain.Entities.Usuarios;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByUidAsync(string uid, CancellationToken cancellationToken);
    }
}