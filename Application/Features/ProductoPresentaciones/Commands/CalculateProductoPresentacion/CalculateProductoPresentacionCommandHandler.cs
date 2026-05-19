using Application.Errors;
using Application.Interfaces;
using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ProductoPresentaciones.Commands.CalculateProductoPresentacion
{
    public class CalculateProductoPresentacionCommandHandler : IRequestHandler<CalculateProductoPresentacionCommand, Result<decimal>>
    {
        private readonly IFilamentoRepository _filamentoRepository;
        private readonly IProductoPricingService _pricingService;
        private readonly ILogger<CalculateProductoPresentacionCommandHandler> _logger;

        public CalculateProductoPresentacionCommandHandler(
            IFilamentoRepository filamentoRepository,
            IProductoPricingService pricingService,
            ILogger<CalculateProductoPresentacionCommandHandler> logger
            )
        {
            _filamentoRepository = filamentoRepository ?? throw new ArgumentNullException(nameof(filamentoRepository));
            _pricingService = pricingService ?? throw new ArgumentNullException(nameof(pricingService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<decimal>> Handle(CalculateProductoPresentacionCommand command, CancellationToken cancellationToken)
        {
            var filamento = await _filamentoRepository.GetByIdTempAsync(
                command.FilamentoId,
                cancellationToken
            );

            if (filamento is null)
            {
                _logger.LogWarning(
                    "Filamento con ID {FilamentoId} no encontrado.",
                    command.FilamentoId
                );

                return Result.Failure<decimal>(
                    FilamentoErrors.NotFound(command.FilamentoId)
                );
            }

            var precioCalculado =
                _pricingService.EstimatePrice(
                    filamento,
                    command.CantidadGramosFilamentoUso,
                    command.TiempoImpresionMinutos,
                    command.CostoProduccionAdicional
                );

            return Result.Success(precioCalculado);
        }
    }
}