using System.Collections.ObjectModel;

namespace Store.Domain.Entities.UserShopping;

public class WishList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<WishListItem>? Items { get; set; }

}


