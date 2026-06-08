using Domain.Entities.Publicaciones;
using Domain.Interfaces;

namespace Infraestructure.Persistence.Repositories
{
    public class PublicacionRepository : BaseRepository<Publicacion>, IPublicacionRepository
    {
        public PublicacionRepository(WebDbContext context) : base(context)
        {

        }
    }
}