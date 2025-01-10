using Microsoft.EntityFrameworkCore;
using Store.Dal.Context;
using Store.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Dal.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext context;

    public Repository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<TEntity?> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await context.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
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
