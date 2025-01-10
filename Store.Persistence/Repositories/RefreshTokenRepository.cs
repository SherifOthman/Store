
using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Persistence.Repositories;
public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext context) : base(context)
    {

    }

    public Task<RefreshToken?> GetByTokenValue(string refreshTokenString, CancellationToken cancellationToken)
    {
        var refreshToken = context.RefreshTokens
             .FirstOrDefaultAsync(r => r.Token == refreshTokenString);

        return refreshToken;
    }

    public Task<RefreshToken?> GetByTokenValueWithUser(string refreshTokenString, CancellationToken cancellationToken)
    {
        var refreshToken = context.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == refreshTokenString);

        return refreshToken;

    }

}
