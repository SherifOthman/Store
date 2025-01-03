using Store.Domain.Common;
using System.Collections.ObjectModel;

namespace Store.Domain.Entities.Products;

public class ProductInventory : TrackedEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public bool IsActive { get; set; }
    public bool IsDigital { get; set; }
    public decimal Price { get; set; }
    public float Weight { get; set; }
    public int UnitsInStock { get; set; }   

    public Collection<ProductInventoryImage>? InventoryImages { get; set; }
    public Collection<ProductAttributeValue>? AttributeValues { get; set; }

    public ProductInventory()
    {
        IsActive = true;
        IsDigital = false;
    }
}


