using Application.Features.Productos.Dtos;
using MediatR;

namespace Application.Features.Productos.Queries.GetCantidadPresentaciones
{
    public class GetCantidadesPresentacionesQuery : IRequest<List<CantidadPresentacionesDto>>
    {
    }
}