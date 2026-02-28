using Application.Features.Catalogos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetTiposInsumo
{
    public class GetTiposInsumoQuery : IRequest<Result<List<CatalogoDto>>>
    {
    }
}