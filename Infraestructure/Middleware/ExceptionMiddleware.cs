using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción no controlada: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, error) = exception switch
            {
                KeyNotFoundException ex => (
                    HttpStatusCode.NotFound,
                    Error.NotFound("General.NotFound", ex.Message)
                ),

                UnauthorizedAccessException ex => (
                    HttpStatusCode.Unauthorized,
                    Error.Unauthorized("General.Unauthorized", ex.Message)
                ),

                OperationCanceledException => (
                    HttpStatusCode.BadRequest,
                    Error.Failure("General.Cancelled", "La operación fue cancelada.")
                ),

                _ => (
                    HttpStatusCode.InternalServerError,
                    Error.Unexpected
                )
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error.Codigo,
                error.Mensaje
            }));
        }
    }
}