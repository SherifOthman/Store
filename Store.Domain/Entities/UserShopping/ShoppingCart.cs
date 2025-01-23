using Store.Domain.Common;

namespace Store.Domain.Entities.UserShopping;

public class ShoppingCart : Entity
{
    public Guid UserId { get; set; }
    public ICollection<ShoppingCartItem>? Items { get; set; }

}


