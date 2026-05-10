using Application.Features.Catalogos.Dtos;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEstadosPublicacion
{
    public class GetEstadosPublicacionQuery : IRequest<List<CatalogoDto>>;
}