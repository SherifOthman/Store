using MediatR;
using Store.Application.Fetures.Usres.Commands.Login;
using Store.Application.Models;
using Store.Application.Responses;

namespace Store.Application.Fetures.Usres.Commands.RefreshTokens;
public record class RefreshTokenCommand(string RefreshToken) : IRequest<Result<TokenResponse>>;
