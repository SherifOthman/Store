using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Persistence;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> IsEmailExists(string email, CancellationToken cancellationToken = default);
}
