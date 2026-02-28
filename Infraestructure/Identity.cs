using Microsoft.AspNetCore.Identity;

namespace Miniaturas.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
}