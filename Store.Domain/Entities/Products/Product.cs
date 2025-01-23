using Store.Domain.Common;

namespace Store.Domain.Entities.Products;

public class Product : TrackedEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Guid BrandId { get; set; }
    public Brand? Brand { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<ProductInventory> Inventories { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}


