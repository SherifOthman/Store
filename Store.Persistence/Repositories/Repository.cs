using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Dal.Context;
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Common;
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


    public Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Set<TEntity>().FindAsync(id, cancellationToken).AsTask();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().UpdateRange(entities);
        await context.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().RemoveRange(entities);
        await context.SaveChangesAsync();
    }

}
