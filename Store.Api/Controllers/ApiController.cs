
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Responses;
using Store.Application.Responses;
using System.Net;

namespace Store.Api.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected BadRequestObjectResult HandleFailure(BaseResult result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException(
                $"Ivalid operation because requst is already successful {nameof(result)}");

        var problemDetails = GetProblemDetailsFromResult(result);

        return BadRequest(problemDetails);
    }


    private ProblemDetails GetProblemDetailsFromResult(BaseResult result)
    {
        var problemDetails = new ProblemDetails
        {
            Title = result.Message ?? "No specific errors provided.",
            Status = (int)HttpStatusCode.BadRequest,
            Instance = HttpContext.Request.Path,
        };

        if (result.Errors != null)
        {
            problemDetails.Detail = "One or more validation errors occurred.";
            problemDetails.Extensions["errors"] = result.Errors;
        }

        return problemDetails;
    }

}
