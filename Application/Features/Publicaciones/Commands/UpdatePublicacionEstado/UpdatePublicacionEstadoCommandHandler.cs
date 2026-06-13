using Application.Errors;
using Application.Features.Productos.Dtos;
using Application.Features.Publicaciones.Commands.AddPublicacion;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Publicaciones.Commands.UpdatePublicacionEstado
{
    public class UpdatePublicacionEstadoCommandHandler : IRequestHandler<UpdatePublicacionEstadoCommand, Result<ProductoBaseDto>>
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly ILogger<AddPublicacionCommandHandler> _logger;

        public UpdatePublicacionEstadoCommandHandler(
            IPublicacionRepository publicacionRepository,
            ILogger<AddPublicacionCommandHandler> logger
            )
        {
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<ProductoBaseDto>> Handle(UpdatePublicacionEstadoCommand command, CancellationToken cancellationToken)
        {

            var publicacion = await _publicacionRepository
                .Query()
                .Include(p => p.Producto)
                .Where(p => p.ProductoId == command.ProductoId)
                .FirstOrDefaultAsync(cancellationToken);

            if(publicacion is null)
            {
                _logger.LogWarning("Publicación de producto con ID {ProductoId} no encontrada.", command.ProductoId);
                return Result.Failure<ProductoBaseDto>(ProductoErrors.NotFound(command.ProductoId));
            }

            publicacion.UpdateEstadoPublicacion(command.EstadoPublicacionCodigo);

            await _publicacionRepository.UpdateAsync(publicacion, cancellationToken);

            var productoBaseDto = publicacion.Producto.Adapt<ProductoBaseDto>() ?? new ProductoBaseDto();

            return Result.Success(productoBaseDto);
        }
    }
}