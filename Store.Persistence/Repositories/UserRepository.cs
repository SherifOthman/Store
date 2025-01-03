using Microsoft.EntityFrameworkCore;
using Store.Dal.Context;
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Dal.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(AppDbContext context)
        : base(context)
    {
        _users = context.Set<User>();
    }

    public override void Remove(User user)
    {
        user.IsDeleted = true;
    }

    public override void RemoveRange(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            Remove(user);
        }
    }

    public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
    {
        return await _users.AsNoTracking()
            .Where(u => u.Roles.Any(r => r.Name.Equals(roleName)))
            .ToListAsync();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _users.SingleOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public Task<bool> ValidateUserAsync(string email, string password)
    {
        return _users.AsNoTracking().AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public Task<User?> GetUserByEmailAndPassword(string email, string passwordHashed)
    {

        return _users.SingleOrDefaultAsync(
            u => u.Email.ToLower() == email.ToLower()
            && u.PasswordHashed == passwordHashed);
    }

}
