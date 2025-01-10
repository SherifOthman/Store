using MediatR;
using Store.Application.Responses;


namespace Store.Application.Fetures.Usres.Commands.Login;


public record LoginCommand(string Email, string Password) : IRequest<Result<TokenResponse>>;

