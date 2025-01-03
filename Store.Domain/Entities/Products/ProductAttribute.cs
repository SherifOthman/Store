using Store.Domain.Enums;

namespace Store.Domain.Entities.Products;

public class ProductAttribute
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ProductAttributeDataType DataType { get; set; }
}


