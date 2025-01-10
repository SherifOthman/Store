using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Fetures.Usres.Commands.Login;
using Store.Application.Fetures.Usres.Commands.RefreshTokens;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Application.Responses;
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
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (response.IsFaliure)
        {
            HandleUnauthorized(response);
        }

        return Ok(response.Value);
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);


        if (response.IsFaliure)
        {
            HandleUnauthorized(response);
        }

        return NoContent();
    }

    [HttpPost("RfreshToken/{token}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TokenResponse>> RefreshToken(string token)
    {
        var response = await _mediator.Send(new RefreshTokenCommand(token));

        if (response.IsFaliure)
        {
            HandleUnauthorized(response);
        }

        return Ok(response.Value);
    }

}


