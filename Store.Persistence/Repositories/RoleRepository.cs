using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories;
public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context)
        : base(context)
    {
    }

    public Task<Role?> GetByNameAsync(string roleName, CancellationToken cancellationToken = default)
    {
        return context.Roles.SingleOrDefaultAsync(r => r.Name == roleName, cancellationToken);
    }


}
