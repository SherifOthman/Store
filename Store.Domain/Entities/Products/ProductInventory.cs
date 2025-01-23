using Store.Domain.Common;
using System.Collections.ObjectModel;

namespace Store.Domain.Entities.Products;

public class ProductInventory : TrackedEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public bool IsDigital { get; set; }
    public decimal Price { get; set; }
    public float Weight { get; set; }
    public int UnitsInStock { get; set; }

    public List<ProductInventoryImage> InventoryImages { get; set; } = new();
    public List<ProductAttributeValue> AttributeValues { get; set; } = new();
}


