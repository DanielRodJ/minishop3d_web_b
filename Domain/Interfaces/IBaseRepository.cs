namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        IQueryable<T> Query();
        IQueryable<T> QueryAsNoTracking();
    }
}