using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Dal.Context;
using Store.Dal.Repositories;
using Store.Domain.Entities.Products;

namespace Store.Persistence.Repositories;
public class CategoryRepository(AppDbContext context) : Repository<Category>(context),
    ICategoryRepository
{
    public Task<Category?> GetWithSubCategoriesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Categories.Include(c => c.SubCategories)
            .SingleOrDefaultAsync(c => c.Id == id && c.IsActive, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllWithSubCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await context.Categories.Include(c => c.SubCategories)
            .ToListAsync(cancellationToken);
    }

}
