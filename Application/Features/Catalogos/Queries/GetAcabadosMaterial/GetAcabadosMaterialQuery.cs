using Application.Features.Catalogos.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Catalogos.Queries.GetAcabadosMaterial
{
    public class GetAcabadosMaterialQuery : IRequest<Result<List<CatalogoDto>>>
    {
    }
}