using Store.Domain.Common;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.Orders;

public class OrderItem : Entity
{
    public Guid OrderId { get; set; }
    public Guid ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
