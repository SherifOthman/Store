using Store.Domain.Common;

namespace Store.Domain.Entities.Products;

public class ProductInventoryImage : Entity
{
    public Guid ProductInventoryId { get; set; }
    public string? ImagePath { get; set; }
    public int DisplayOreder { get; set; }
   
}


