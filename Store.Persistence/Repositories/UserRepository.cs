using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Persistence.Repositories;
public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return context.Users.Include(u => u.Roles)
              .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public Task<bool> IsEmailExists(string email, CancellationToken cancellationToken = default)
        {
        return context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }
}
