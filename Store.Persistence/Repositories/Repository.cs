using Microsoft.EntityFrameworkCore;
using Store.Dal.Context;
using Store.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext context;

    public Repository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await context.Set<TEntity>()
            .Where(predicate)
            .ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await context.Set<TEntity>().AddRangeAsync(entities);
    }

    public virtual void Remove(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().RemoveRange(entities);
    }


}
