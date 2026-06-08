using Application.Common.Helpers;
using Application.Errors;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities.Publicaciones;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Publicaciones.Commands.AddPublicacion
{
    public class AddPublicacionCommandHandler : IRequestHandler<AddPublicacionCommand, Result<long>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<AddPublicacionCommandHandler> _logger;

        public AddPublicacionCommandHandler(
            IProductoRepository productoRepository,
            IPublicacionRepository publicacionRepository,
            IDateTimeService dateTimeService,
            ILogger<AddPublicacionCommandHandler> logger
            )
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _publicacionRepository = publicacionRepository ?? throw new ArgumentNullException(nameof(publicacionRepository));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<long>> Handle(AddPublicacionCommand command, CancellationToken cancellationToken)
        {

            var producto = await _productoRepository.GetByIdAsync(command.ProductoId, cancellationToken);

            if (producto is null)
            {
                _logger.LogWarning("Producto con ID {ProductoId} no encontrado.", command.ProductoId);
                return Result.Failure<long>(ProductoErrors.NotFound(command.ProductoId));
            }

            if (producto.IsDeleted)
            {
                _logger.LogWarning("Producto con ID {ProductoId} fue eliminado.", command.ProductoId);
                return Result.Failure<long>(ProductoErrors.Deleted(command.ProductoId));
            }

            var publicacionActivaQuery = _publicacionRepository
                .QueryAsNoTracking()
                .Where(p => p.ProductoId == command.ProductoId
                    && p.EstadoPublicacionCodigo == EstadoPublicacionCatalogo.Activa.Codigo
                    && !p.IsDeleted
                );

            var publicacionActiva = await publicacionActivaQuery.AnyAsync(cancellationToken);

            if (publicacionActiva is true)
            {
                _logger.LogWarning("Producto con ID {ProductoId} ya tiene una publicación activa.", command.ProductoId);
                return Result.Failure<long>(PublicacionErrors.PublicacionActivaExistente(command.ProductoId));
            }

            Publicacion nuevaPublicacion;

            var slug = SlugHelper.Generate(command.TituloPublicacion); // TO DO : el slug debe ser único, por ahora se asume que el título es único o que no habrá conflictos de slug.

            if (EstadoPublicacionCatalogo.Activa.Codigo.Equals(command.EstadoPublicacionCodigo))
            {
                nuevaPublicacion = Publicacion.NewPublicacion(
                    titulo: command.TituloPublicacion,
                    descripcion: command.DescripcionPublicacion,
                    productoId: command.ProductoId,
                    estadoPublicacionCodigo: command.EstadoPublicacionCodigo,
                    destacado: command.Destacado,
                    fechaPublicacion: _dateTimeService.UtcNow,
                    slug: slug
                );
            }
            else
            {
                nuevaPublicacion = Publicacion.NewBorrador(
                    titulo: command.TituloPublicacion,
                    descripcion: command.DescripcionPublicacion,
                    productoId: command.ProductoId,
                    estadoPublicacionCodigo: command.EstadoPublicacionCodigo,
                    destacado: command.Destacado,
                    slug: slug
                );
            }

            await _publicacionRepository.AddAsync(nuevaPublicacion, cancellationToken);

            return Result.Success(nuevaPublicacion.PublicacionId);
        }
    }
}