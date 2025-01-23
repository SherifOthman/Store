
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.UserShopping;

public class ShoppingCartItem
{
    public Guid ShoppingCartId { get; set; }
    public Guid ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
    public int Quantity { get; set; }
}


