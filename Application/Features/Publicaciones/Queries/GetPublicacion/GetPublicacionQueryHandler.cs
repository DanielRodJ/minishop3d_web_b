using Application.Errors;
using Application.Features.Publicaciones.Dtos;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Publicaciones.Queries.GetPublicacion
{
    public class GetPublicacionQueryHandler : IRequestHandler<GetPublicacionQuery, Result<PublicacionDto>>
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly ILogger<GetPublicacionQueryHandler> _logger;

        public GetPublicacionQueryHandler(
            IPublicacionRepository publicacionRepository,
            ILogger<GetPublicacionQueryHandler> logger
            )
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<PublicacionDto>> Handle(GetPublicacionQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Iniciando obtención de publicación con ID {PublicacionId}.", request.PublicacionId);

            var publicacion = await _publicacionRepository
                .QueryAsNoTracking()
                .Where(p => p.PublicacionId == request.PublicacionId)
                .FirstOrDefaultAsync(cancellationToken);

            if (publicacion is null)
                return Result.Failure<PublicacionDto>(PublicacionErrors.NotFound(request.PublicacionId));

            if (publicacion.IsDeleted)
                return Result.Failure<PublicacionDto>(PublicacionErrors.Deleted(request.PublicacionId));

            var publicacionDto = publicacion.Adapt<PublicacionDto>();

            return Result.Success(publicacionDto);

        }
    }
}