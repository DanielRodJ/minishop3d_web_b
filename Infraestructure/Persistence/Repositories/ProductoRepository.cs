using Domain.Entities.Productos;
using Domain.Interfaces;

namespace Infraestructure.Persistence.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(WebDbContext context) : base(context)
        {
        }
    }
}