using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Infraestructure.Auth
{
    public class FirebaseAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public FirebaseAuthHandler(
           IOptionsMonitor<AuthenticationSchemeOptions> options,
           ILoggerFactory logger,
           UrlEncoder encoder,
           ISystemClock clock)
           : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Logger.LogDebug("Iniciando verificación de usuario con Firebase");

            // 1. Validación de existencia del header
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader is null || !authHeader.StartsWith("Bearer "))
                return AuthenticateResult.NoResult();

            var token = authHeader.Substring("Bearer ".Length);

            try
            {
                // 2. Verificación de token con Firebase.
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);

                // 3. Obtención de información mediante token.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, decodedToken.Uid)
                };

                if (decodedToken.Claims.TryGetValue("email", out var emailObj) && emailObj is string email)
                {
                    claims.Add(new Claim(ClaimTypes.Email, email));
                }
                else
                {
                    return AuthenticateResult.Fail("El token de Firebase no contiene un correo electrónico válido.");
                }

                if (decodedToken.Claims.TryGetValue("name", out var nameObj) && nameObj is string name)
                {
                    claims.Add(new Claim(ClaimTypes.Name, name));
                }

                // 4. Generación de ticket. 
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Ha ocurrido un error durante la verificación de token de Firebase.");
                return AuthenticateResult.Fail("El token de Firebase es inválido o a expirado.");
            }
        }
    }
}