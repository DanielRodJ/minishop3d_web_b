using Application.Features.Catalogos.Dtos;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEscalas
{
    public class GetEscalasQuery : IRequest<List<CatalogoDto>>;
}