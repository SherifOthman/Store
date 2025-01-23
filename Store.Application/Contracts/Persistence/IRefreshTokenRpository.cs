using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Persistence;
public interface IRefreshTokenRpository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetRefreshTokenByValue(string value, CancellationToken cancellationToken = default);

    Task<int> RemoveInvalidTokens(CancellationToken cancellationToken = default);
}
