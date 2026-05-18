using Application.Features.Catalogos.Dtos;
using Application.Features.Filamentos.Dtos;
using MediatR;

namespace Application.Features.Filamentos.Queries.GetListaFilamentos
{
    public class GetListaFilamentosQuery : IRequest<List<FilamentoDto>>;
}