using Domain.Entities.Usuarios;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(WebDbContext context) : base(context)
        {
        }
        
        public Task<Usuario?> GetByUidAsync(string uid, CancellationToken cancellationToken)
        {
            return _context.Usuarios
                .FirstOrDefaultAsync(u => u.Uid == uid && !u.IsDeleted);
        }
    }
}