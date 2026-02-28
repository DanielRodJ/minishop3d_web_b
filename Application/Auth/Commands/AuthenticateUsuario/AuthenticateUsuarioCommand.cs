using MediatR;

namespace Application.Auth.Commands.AuthenticateUsuario
{
    public class AuthenticateUsuarioCommand : IRequest<bool>
    {
        public string Uid { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;

        public AuthenticateUsuarioCommand(string uid, string email, string? name)
        {
            Uid = uid;
            Email = email;
            Name = name;
        }
    }
}