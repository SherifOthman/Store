using Store.Domain.Common;
using Store.Domain.Entities.Users;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Orders;

public class Order : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime OrderDate { get; private set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public Shipping Shipping { get; set; } = null!;
    public Payment Payment { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = null!;

    public Order()
    {
        OrderDate = DateTime.UtcNow;
    }

}
