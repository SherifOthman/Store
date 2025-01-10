using Store.Domain.Abstractions.Repositories;

namespace Store.Application.Contracts.Persistence;
public interface IUnitOfWork : IAsyncDisposable
{
    IRoleRepository Roles { get; }
    IRefreshTokenRepository RefreshTokens { get; }

    public Task<int> CompleteAsync(CancellationToken token);

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

}
