using Application.Interfaces;
using Domain.Entities.Productos;

namespace Infraestructure.Services
{
    public class ProductoPricingService : IProductoPricingService
    {
        private const decimal COSTO_POR_MINUTO = 0.5m;
        private const decimal MARGEN = 0.30m;

        public decimal EstimatePrice(Filamento filamento, decimal cantidadGramos, int tiempoImpresionMinutos, decimal costoProduccionAdicional)
        {
            var costoFilamento =
                cantidadGramos * filamento.PrecioPorGramo;

            var costoTiempo =
                tiempoImpresionMinutos * COSTO_POR_MINUTO;

            var costoBase =
                costoFilamento +
                costoTiempo +
                costoProduccionAdicional;

            var precioFinal =
                costoBase * (1 + MARGEN);

            return Math.Round(precioFinal, 2);
        }
    }
}