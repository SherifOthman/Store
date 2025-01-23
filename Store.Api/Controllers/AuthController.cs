using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Users.Commands.Login;
using Store.Application.Features.Usres.Commands.RefreshTokens;
using Store.Application.Responses;

namespace Store.Api.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (response.Error)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (response.Error)
        {
            return BadRequest(response);
        }

        return NoContent();
    }

    [HttpPost("RfreshToken/{token}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TokenResponse>> RefreshToken(string token)
    {
        var response = await _mediator.Send(new RefreshTokenCommand(token));

        if (response.Error)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

}


