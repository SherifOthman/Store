using AutoMapper;
using MediatR;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Application.Fetures.Usres.Commands.Login;
using Store.Application.Responses;

namespace Store.Application.Features.Users.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<TokenResponse>>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly ILoggedInService _loggedInService;
    private readonly IUserManager _userManager;

    public LoginCommandHandler(
        IJwtProvider jwtProvider,
        ILoggedInService loggedInService,
        IUserManager userManager)
    {
        _jwtProvider = jwtProvider;
        _loggedInService = loggedInService;
        _userManager = userManager;
    }

    public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        var user = await _userManager.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null || !_userManager.ValidatePassword(user, request.Password))
            return Result<TokenResponse>.FailureWithMessage("Invalid email or password");

     
        var accessToken = _jwtProvider.GenerateAccessToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();


        await _userManager.RevokeRefreshTokensByIpAddressAsync(_loggedInService.IpAddress!, cancellationToken);
        await _userManager.AssignRefreshTokenToUserAsync(user, refreshToken.Token, refreshToken.ExpiresIn, _loggedInService.IpAddress!, cancellationToken);
        

        var response = new TokenResponse
        {
            AccessToken = accessToken.Token,
            ExpiresIn = accessToken.ExpiresIn,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiresIn = refreshToken.ExpiresIn
        };

        return response;
    }
}
