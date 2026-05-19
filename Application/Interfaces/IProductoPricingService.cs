using Domain.Entities.Productos;

namespace Application.Interfaces
{
    public interface IProductoPricingService
    {
        decimal EstimatePrice(Filamento filamento, decimal cantidadGramos, int tiempoImpresionMinutos, decimal costoProduccionAdicional);
    }
}