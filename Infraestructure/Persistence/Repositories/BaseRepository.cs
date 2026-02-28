
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly WebDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(WebDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken) is not null;
        }

        public async Task AddAsync(T entidad, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entidad, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entidad, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entidad);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entidad, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entidad);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> QueryAsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }
    }
}
