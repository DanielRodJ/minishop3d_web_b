
namespace Application.Features.Productos.Dtos
{
    public class CantidadPresentacionesDto
    {
        public int ProductoId { get; set; }
        public int CantidadTotalPresentaciones { get; set; }
        public int CantidadPresentacionesEnEstadoDisponible { get; set; }
    }
}