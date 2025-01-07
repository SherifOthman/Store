using Store.Domain.Entities.Users;

namespace Store.Domain.Abstractions.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);

    Task<bool> IsEmailRegisteredAsync(string email);

    Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName);
}
