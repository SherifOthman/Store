using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Fetures.Usres.Commands.Login;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Domain.Entities.Orders;
using System.Diagnostics;

namespace Store.Api.Controllers;
[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (!response.IsSuccess)
        {
            return Unauthorized(new { Error = response.Message });
        }

        return Ok(response.Value);
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (!response.IsSuccess)
        {
            return HandleFailure(response);
        }

        return NoContent();
    }

}


