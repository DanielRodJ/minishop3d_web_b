using Domain.Common;
using MediatR;

namespace Application.Features.ProductoPresentaciones.Commands.AddProductoPresentacion
{
    public class AddProductoPresentacionCommand : IRequest<Result<long>>
    {
        public int ProductoId { get; set; }
        public long FilamentoId { get; set; }
        public string EscalaCodigo { get; set; } = string.Empty;
        public decimal DimensionX { get; set; }
        public decimal DimensionY { get; set; }
        public decimal DimensionZ { get; set; }
        public int TiempoImpresionMinutos { get; set; }
        public decimal CantidadGramosFilamentoUso { get; set; }
        public string EstadoProductoPresentacionCodigo { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal CostoProduccionAdcional { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}