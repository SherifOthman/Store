
using Microsoft.AspNetCore.Mvc;
using Store.Application.Responses;

namespace Store.Api.Controllers;

public class ApiController : ControllerBase
{

    public IActionResult HandleFailure<T>(Result<T> result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException($"Requst is successful {nameof(result)}");

        var response = new
        {
            Message = result.Message ?? "An error occurrdd",
            result.ValidationErrors
        };

        return BadRequest(response);
    }
}
