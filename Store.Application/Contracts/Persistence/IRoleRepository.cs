using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Persistence;
public interface IRoleRepository : IRoleRepository<Role>
{
    Task<Role?> GetByNameAsync(string roleName);
}
