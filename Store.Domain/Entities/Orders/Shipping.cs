using Store.Domain.Common;
using Store.Domain.Entities.Users;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Orders;

public class Shipping : Entity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int AddressId { get; set; }
    public ShippingStatus Status { get; set; }
    public ShippingMethod Method { get; set; }
    public DateTime ShippedDate { get; private set; }
    public DateTime? DeliveryDate { get; set; }


    public Shipping()
    {
        ShippedDate = DateTime.UtcNow;
    }
}
