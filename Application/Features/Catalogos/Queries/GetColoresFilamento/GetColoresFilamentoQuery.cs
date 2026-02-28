using Application.Features.Catalogos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetColoresFilamento
{
    public class GetColoresFilamentoQuery : IRequest<Result<List<CatalogoDto>>>
    {
    }
}