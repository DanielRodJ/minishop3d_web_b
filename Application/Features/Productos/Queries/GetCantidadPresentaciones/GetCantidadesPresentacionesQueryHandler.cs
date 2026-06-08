using Application.Features.Productos.Dtos;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Productos.Queries.GetCantidadPresentaciones
{
    public class GetCantidadesPresentacionesQueryHandler : IRequestHandler<GetCantidadesPresentacionesQuery, List<CantidadPresentacionesDto>>
    {
        private readonly IProductoPresentacionRepository _productoPresentacionRepository;
        private readonly ILogger<GetCantidadesPresentacionesQueryHandler> _logger;

        public GetCantidadesPresentacionesQueryHandler(
            IProductoPresentacionRepository productoPresentacionRepository,
            ILogger<GetCantidadesPresentacionesQueryHandler> logger)
        {
            _productoPresentacionRepository = productoPresentacionRepository ?? throw new ArgumentNullException(nameof(productoPresentacionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<CantidadPresentacionesDto>> Handle(GetCantidadesPresentacionesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando obtención de cantidades presentaciones asociadas a productos");

            var cantidadesPresentaciones = await _productoPresentacionRepository
                .QueryAsNoTracking()
                .Where(pp => !pp.IsDeleted)
                .GroupBy(pp => pp.ProductoId)
                .Select(g => new CantidadPresentacionesDto
                {
                    ProductoId = g.Key,
                    CantidadTotalPresentaciones = g.Count(),
                    CantidadPresentacionesEnEstadoDisponible = g.Count(pp => pp.EstadoProductoPresentacionCodigo == EstadoProductoCatalogo.Disponible.Codigo)
                })
                .ToListAsync(cancellationToken);

            return cantidadesPresentaciones;
        }
    }
}