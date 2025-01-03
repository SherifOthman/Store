using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Infrastructure.Authentication;
public interface IJwtProvider
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    string RenewAccessToken(string RefreshToken);
}
