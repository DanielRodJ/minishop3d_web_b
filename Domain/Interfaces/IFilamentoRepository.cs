using Domain.Entities.Productos;

namespace Domain.Interfaces
{
    public interface IFilamentoRepository : IBaseRepository<Filamento>
    {
        Task<Filamento?> GetByIdTempAsync(long id, CancellationToken cancellationToken = default);
     }
}