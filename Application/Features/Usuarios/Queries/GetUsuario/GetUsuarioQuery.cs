using Application.Dtos.Usuarios;
using MediatR;

namespace Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioQuery : IRequest<UsuarioBaseDto>
    {
        public int? UsuarioId { get; set; }
        public string? ExternalId { get; set; }

        public GetUsuarioQuery(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public GetUsuarioQuery(string externalId)
        {
            ExternalId = externalId;
        }
    }
}