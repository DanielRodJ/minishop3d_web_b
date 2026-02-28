using Domain.Entities.Productos;
using Domain.Interfaces;

namespace Infraestructure.Persistence.Repositories
{
    public class ColeccionRepository : BaseRepository<Coleccion>, IColeccionRepository
    {
        public ColeccionRepository(WebDbContext context) : base(context)
        {
        }
    }
}