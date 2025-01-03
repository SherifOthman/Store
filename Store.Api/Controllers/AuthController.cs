using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Fetures.Usres.Commands.Login;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Dal.Repositories;

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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginCommand request,
        CancellationToken cancellation)
    {
        var command = new LoginCommand(request.Email, request.Password);

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    //[HttpPost]
    //public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    //{

    //    var response = await _mediator.Send(request);

    //    if (!response.IsSuccess)
    //    {
    //       // return HandleFailure(response);
    //    }

    //    return Ok("Account Registerd successfully");
    //}

}


