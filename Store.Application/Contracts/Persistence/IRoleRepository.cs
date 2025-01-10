
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Persistence;
public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(string RoleName, CancellationToken token);
}
