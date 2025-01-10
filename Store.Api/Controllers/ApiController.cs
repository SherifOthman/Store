using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Responses;
using Store.Application.Responses;
using System.Net;

namespace Store.Api.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected UnauthorizedObjectResult HandleUnauthorized(BaseResult result)
    {
        EnsureFailure(result);
        var problemDetails = CreateProblemDetails(result, HttpStatusCode.Unauthorized, "Access was denied.");
        return Unauthorized(problemDetails);
    }

    protected BadRequestObjectResult HandleBadRequest(BaseResult result)
    {
        EnsureFailure(result);
        var problemDetails = CreateProblemDetails(result, HttpStatusCode.BadRequest, "One or more validation errors occurred.");
        return BadRequest(problemDetails);
    }

    private void EnsureFailure(BaseResult result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException(
                $"Invalid operation because the request was already successful: {nameof(result)}");
        }
    }

    private ProblemDetails CreateProblemDetails(BaseResult result, HttpStatusCode statusCode, string? defaultDetail = null)
    {
        var problemDetails = new ProblemDetails
        {
            Title = result.Message ?? "No specific errors provided.",
            Status = (int)statusCode,
            Instance = HttpContext.Request.Path,
        };

        if (result.Errors != null)
        {
            problemDetails.Extensions["errors"] = result.Errors;

            if (defaultDetail != null)
                problemDetails.Detail = defaultDetail;

        }

        return problemDetails;
    }
}
