using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Abstractions.Repositories;

public interface IUserRepository : IRepository<User>
{

    Task<bool> ValidateUserAsync(string email, string password);

    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetUserByEmailAndPassword(string email, string passwordHashed);

    Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName);
}
