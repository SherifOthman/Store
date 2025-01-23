using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.Services;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Domain.Entities.Users;

namespace Store.Infrastructure.Services;
public class TokenService : ITokenService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IRefreshTokenRpository _refreshTokenRepository;

    public TokenService(IJwtProvider jwtProvider, Application.Contracts.Persistence.IRefreshTokenRpository refreshTokenRepository)
    {
        _jwtProvider = jwtProvider;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<TokenResponse> GenerateTokensAsync(User user, CancellationToken cancellationToken)
    {
        var accessTokenVm = _jwtProvider.GenerateAccessToken(user);
        var refreshTokenVm = _jwtProvider.GenerateRefreshToken();

        var refreshToken = RefreshToken.Create(user.Id, refreshTokenVm.Token, refreshTokenVm.ExpiresIn);
        await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);

        return new TokenResponse
        {
            AccessToken = accessTokenVm.Token,
            ExpiresIn = (long) accessTokenVm.ExpiresIn.Subtract(DateTime.UtcNow).TotalSeconds,
            RefreshToken = refreshTokenVm.Token,
            RefreshTokenExpiresIn =(long) refreshTokenVm.ExpiresIn.Subtract(DateTime.UtcNow).TotalSeconds
        };

    }
}
