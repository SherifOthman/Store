using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Persistence;
public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenValue(string refreshTokenString, CancellationToken cancellationToken);
   
    Task<RefreshToken?> GetByTokenValueWithUser(string refreshTokenString, CancellationToken cancellationToken);
}
