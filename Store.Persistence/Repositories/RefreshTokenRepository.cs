
using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Persistence.Repositories;
public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRpository
{
    public RefreshTokenRepository(AppDbContext context) : base(context)
    {

    }

    public Task<RefreshToken?> GetRefreshTokenByValue(string value, CancellationToken cancellationToken = default)
    {
        var refreshToken = context.RefreshTokens
             .FirstOrDefaultAsync(r => r.Token == value);

        return refreshToken;
    }

    public Task<int> RemoveInvalidTokens(CancellationToken cancellationToken = default)
    {
        return context.RefreshTokens
            .Where(r => r.IsRevoked || r.CreatedOn > DateTime.UtcNow)
            .ExecuteDeleteAsync(cancellationToken);


    }
}
