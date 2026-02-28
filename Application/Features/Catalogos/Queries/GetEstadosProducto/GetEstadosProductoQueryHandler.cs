using Application.Features.Catalogos.Dtos;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Catalogos.Queries.GetEstadosProducto
{
    public class GetEstadosProductoQueryHandler : IRequestHandler<GetEstadosProductoQuery, Result<List<CatalogoDto>>>
    {
        private readonly ILogger<GetEstadosProductoQueryHandler> _logger;

        public Task<Result<List<CatalogoDto>>> Handle(GetEstadosProductoQuery request, CancellationToken cancellationToken)
        {
            var estadosProducto = EstadoProductoCatalogo.List
                .OrderBy(x => x.Numero)
                .Select(x => new CatalogoDto(x.Nombre, x.Codigo))
                .ToList();

            return Task.FromResult(Result.Success(estadosProducto));
        }
    }
}