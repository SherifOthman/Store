using Store.Domain.Common;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Products;

public class ProductAttribute : Entity
{
    public required string Name { get; set; }
    public ProductAttributeDataType DataType { get; set; }
}


