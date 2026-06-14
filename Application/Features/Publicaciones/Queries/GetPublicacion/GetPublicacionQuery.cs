using Application.Features.Publicaciones.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Features.Publicaciones.Queries.GetPublicacion
{
    public class GetPublicacionQuery : IRequest<Result<PublicacionDto>>
    {
       public long PublicacionId { get; set; }
       
       public GetPublicacionQuery(long publicacionId)
        {
            PublicacionId = publicacionId;
        }
    }
}