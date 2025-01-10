
using MediatR;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Application.Contracts.Persistence;

using Store.Application.Responses;
using Store.Domain.Entities.Users;

namespace Store.Application.Fetures.Usres.Commands.RefreshTokens;
public class RefreshTokenCommandHanlder : IRequestHandler<RefreshTokenCommand, Result<TokenResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserManager _userManager;
    private readonly IJwtProvider _jwtProvider;
    private readonly ILoggedInService _loggedInService;

    public RefreshTokenCommandHanlder(IUnitOfWork unitOfWork, IUserManager userManager,
        IJwtProvider jwtProvider, ILoggedInService loggedInService)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _jwtProvider = jwtProvider;
        _loggedInService = loggedInService;
    }

    public async Task<Result<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {

        var oldRefreeshToken = await _unitOfWork.RefreshTokens.GetByTokenValueWithUser(request.RefreshToken, cancellationToken);

        if (oldRefreeshToken == null || !IsRefreshTokenValid(oldRefreeshToken))
        {
            return Result<TokenResponse>.FailureWithMessage("Invalid Refresh Token");
        }

        var newAccessToken = _jwtProvider.GenerateAccessToken(oldRefreeshToken.User);
        var newRefreshToken = _jwtProvider.GenerateRefreshToken();

        await _userManager.AssignRefreshTokenToUserAsync(oldRefreeshToken.User, newRefreshToken.Token,
           newRefreshToken.ExpiresIn, _loggedInService.IpAddress!, cancellationToken);
        
        await _userManager.MarkTokenAsUsed(oldRefreeshToken.Token, cancellationToken);

        return new TokenResponse
        {
            AccessToken = newAccessToken.Token,
            ExpiresIn = newAccessToken.ExpiresIn,
            RefreshToken = newRefreshToken.Token,
            RefreshTokenExpiresIn = newRefreshToken.ExpiresIn
        };

    }

    private bool IsRefreshTokenValid(RefreshToken token)
    {
        // Token has expired
        if (token.ExpiresOn <= DateTime.UtcNow)
            return false;

        // Token is either used or revoked
        return !(token.IsUsed || token.IsRevoked);
    }
}
