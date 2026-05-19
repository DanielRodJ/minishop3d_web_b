using Domain.Common;
using MediatR;

namespace Application.Features.ProductoPresentaciones.Commands.CalculateProductoPresentacion
{
    public class CalculateProductoPresentacionCommand : IRequest<Result<decimal>>
    {
        public long FilamentoId { get; set; }
        public string EscalaCodigo { get; set; } = string.Empty;
        public int TiempoImpresionMinutos { get; set; }
        public decimal CantidadGramosFilamentoUso { get; set; }
        public decimal CostoProduccionAdicional { get; set; }
    }
}