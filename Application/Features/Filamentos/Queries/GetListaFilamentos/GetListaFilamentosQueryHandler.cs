using Application.Features.Filamentos.Dtos;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Filamentos.Queries.GetListaFilamentos
{
    public class GetListaFilamentosQueryHandler
        : IRequestHandler<GetListaFilamentosQuery, List<FilamentoDto>>
    {
        private readonly IFilamentoRepository _filamentoRepository;

        public GetListaFilamentosQueryHandler(
            IFilamentoRepository filamentoRepository,
            ILogger<GetListaFilamentosQueryHandler> logger)
        {
            _filamentoRepository = filamentoRepository ?? throw new ArgumentNullException(nameof(filamentoRepository));
        }

        public async Task<List<FilamentoDto>> Handle(
            GetListaFilamentosQuery request,
            CancellationToken cancellationToken)
        {
            return await _filamentoRepository
                .QueryAsNoTracking()
                .Where(x => x.Activo)
                .OrderBy(x => x.Nombre)
                .ThenBy(x => x.TipoMaterial)
                .ThenBy(x => x.Color)
                .ProjectToType<FilamentoDto>()
                .ToListAsync(cancellationToken);
        }
    }
}