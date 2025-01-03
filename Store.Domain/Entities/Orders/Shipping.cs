using Store.Domain.Entities.Users;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Orders;

public class Shipping
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
    public ShippingStatus Status { get; set; }
    public ShippingMethod Method { get; set; }
    public DateTime ShippedDate { get; private set; }
    public DateTime? DeliveryDate { get; set; }


    public Shipping()
    {
        ShippedDate = DateTime.UtcNow;
    }
}
