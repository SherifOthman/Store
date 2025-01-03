using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Abstractions.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
