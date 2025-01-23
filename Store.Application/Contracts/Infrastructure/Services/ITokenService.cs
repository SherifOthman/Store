using Store.Application.Responses;
using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Infrastructure.Services;
public interface ITokenService
{
    Task<TokenResponse> GenerateTokensAsync(User user, CancellationToken cancellationToken);

}
