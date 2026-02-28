using Application.Features.Catalogos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetEscalas
{
    public class GetEscalasQuery : IRequest<Result<List<CatalogoDto>>>
    {
    }
}