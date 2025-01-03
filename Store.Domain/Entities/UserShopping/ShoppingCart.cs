using Store.Domain.Entities.Users;
using System.Collections.ObjectModel;

namespace Store.Domain.Entities.UserShopping;

public class ShoppingCart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<ShoppingCartItem>? Items { get; set; }

}


