using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Abstractions.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync(int id, CancellationToken token);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token);
    Task AddAsync(TEntity entity, CancellationToken token);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
