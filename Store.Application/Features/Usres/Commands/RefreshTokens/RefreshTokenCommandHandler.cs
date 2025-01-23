using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.Services;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Application.Wrappers;

namespace Store.Application.Features.Usres.Commands.RefreshTokens;
public record class RefreshTokenCommand(string RefreshToken) : IRequestWrapper<TokenResponse>;

public class RefreshTokenCommandHandler : IHandler<RefreshTokenCommand, TokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRpository _refreshTokenRepository;
    private readonly ITokenService _tokenService;

    public RefreshTokenCommandHandler(IUserRepository userRepository,
        IRefreshTokenRpository refreshTokenRepository,
        ITokenService tokenService) 
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenService = tokenService;
    }

    public async Task<Response<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {

        var refreshToken = await _refreshTokenRepository.GetRefreshTokenByValue(request.RefreshToken);

        if (refreshToken == null || !refreshToken.IsValid())
        {
            return Response.Fail<TokenResponse>("Ivalid Refresh Token");
        }

        var user = await _userRepository.GetAsync(refreshToken.UserId, cancellationToken);
        var newToken = await _tokenService.GenerateTokensAsync(user!, cancellationToken);

        await _refreshTokenRepository.RemoveAsync(refreshToken);
        return newToken;

    }

}
