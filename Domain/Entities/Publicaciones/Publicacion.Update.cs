
namespace Domain.Entities.Publicaciones
{
    public partial class Publicacion
    {
        public void UpdateEstadoPublicacion(string estadoPublicacionCodigo)
        {
            EstadoPublicacionCodigo = estadoPublicacionCodigo;
        }
    }
}