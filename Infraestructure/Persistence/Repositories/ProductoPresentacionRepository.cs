using Domain.Entities.Productos;
using Domain.Interfaces;

namespace Infraestructure.Persistence.Repositories
{
    public class ProductoPresentacionRepository : BaseRepository<ProductoPresentacion>, IProductoPresentacionRepository
    {
        public ProductoPresentacionRepository(WebDbContext context) : base(context)
        {
        }
    }
}