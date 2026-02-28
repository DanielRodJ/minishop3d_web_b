using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int? UsuarioId => null;

    public bool EsAdmin => false;

    public string? FirebaseUid =>
        _httpContextAccessor.HttpContext?
            .User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public string? FirebaseUsername =>
        _httpContextAccessor.HttpContext?
            .User.FindFirst(ClaimTypes.Name)?.Value;

    public string? FirebaseEmail =>
        _httpContextAccessor.HttpContext?
            .User.FindFirst(ClaimTypes.Email)?.Value;

    public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?
            .User.Identity?.IsAuthenticated ?? false;
}