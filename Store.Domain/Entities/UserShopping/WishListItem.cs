
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.UserShopping;

public class WishListItem
{
    public Guid WishListId { get; set; }
    public Guid ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
}


