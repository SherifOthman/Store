
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.UserShopping;

public class WishListItem
{
    public int WishListId { get; set; }
    public int ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
}


