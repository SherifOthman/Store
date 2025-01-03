using Store.Domain.Abstractions.Repositories;

namespace Store.Application.Contracts.Persistence;
public interface IUnitOfWork : IAsyncDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }

    public Task<int> CompleteAsync();

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

}
