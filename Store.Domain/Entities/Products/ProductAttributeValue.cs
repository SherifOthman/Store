namespace Store.Domain.Entities.Products;

public class ProductAttributeValue
{
    public Guid AttributeId { get; set; }
    public ProductAttribute Attribute { get; set; } = null!;
    public Guid ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
    public required string value { get; set; }
}


