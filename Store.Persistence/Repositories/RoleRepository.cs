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
public class RoleRepository : Repository<Role>,  IRoleRepository
{
    private readonly DbSet<Role> _Role;

    public RoleRepository(AppDbContext context)
        :base(context)
    {
        _Role = context.Set<Role>();
    }

    public Task<Role?> GetByNameAsync(string roleName)
    {
        return _Role.SingleOrDefaultAsync(r=>r.Name.Equals(roleName, StringComparison.OrdinalIgnoreCase));
    }
}
