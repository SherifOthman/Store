using Store.Domain.Common;

namespace Store.Domain.Entities.Products;

public class Product : TrackedEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<ProductInventory> Inventories { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = null!;


    public Product()
    {
        IsActive = true;
    }
}


