
namespace Application.Features.Catalogos.Dtos
{
    public class CatalogoDto
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public CatalogoDto(string nombre, string codigo)
        {
            Nombre = nombre;
            Codigo = codigo;
        }
    }
}