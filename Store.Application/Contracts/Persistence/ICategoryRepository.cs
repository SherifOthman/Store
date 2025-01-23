using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Products;

namespace Store.Application.Contracts.Persistence;
public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetWithSubCategoriesAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Category>> GetAllWithSubCategoriesAsync(CancellationToken cancellationToken = default);

}
