using Domain.Entities.Productos;
using Domain.Interfaces;

namespace Infraestructure.Persistence.Repositories
{
    public class FilamentoRepository : BaseRepository<Filamento>, IFilamentoRepository
    {
        public FilamentoRepository(WebDbContext context) : base(context)
        {

        }

        public async Task<Filamento?> GetByIdTempAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(
                new object[] { id },
                cancellationToken);
        }
    }
}