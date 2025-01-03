using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public IUserRepository Users => field ?? new UserRepository(_context);
    public IRoleRepository Roles => field ?? new RoleRepository(_context);


    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = null!;
        Roles = null!;
    }


    public Task<int> CompleteAsync()
    {
        return _context.SaveChangesAsync();
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (typeof(User).IsAssignableFrom(typeof(TEntity)))
        {
            throw new InvalidOperationException("The type TEntity cannot be User or a derived type of User.");
        }

        var entityType = typeof(TEntity);

        if (_repositories.ContainsKey(entityType))
        {
            return (IRepository<TEntity>)_repositories[entityType];
        }
        else
        {
            var newRepo = new Repository<TEntity>(_context);
            _repositories.Add(entityType, newRepo);
            return newRepo;
        }
    }
}
