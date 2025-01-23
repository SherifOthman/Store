using Store.Domain.Common;
using System.Collections.ObjectModel;

namespace Store.Domain.Entities.UserShopping;

public class WishList : Entity
{
    public Guid UserId { get; set; }
    public ICollection<WishListItem>? Items { get; set; }

}


