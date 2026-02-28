using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace minishop3d_api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);

            return HandleFailure(result);
        }

        protected IActionResult HandleResult(Result result)
        {
            if (result.IsSuccess)
                return NoContent();

            return HandleFailure(result);
        }

        private IActionResult HandleFailure(Result result)
        {
            return result.Error.Tipo switch
            {
                ErrorType.NotFound => NotFound(ProblemDetails(result.Error)),
                ErrorType.Validation => BadRequest(ProblemDetails(result.Error)),
                ErrorType.Conflict => Conflict(ProblemDetails(result.Error)),
                ErrorType.Unauthorized => Unauthorized(ProblemDetails(result.Error)),
                ErrorType.Unexpected => StatusCode(500, ProblemDetails(result.Error)),
                _ => StatusCode(500, ProblemDetails(result.Error))
            };
        }

        private static object ProblemDetails(Error error)
        {
            return new
            {
                error.Codigo,
                error.Mensaje
            };
        }
    }
}
