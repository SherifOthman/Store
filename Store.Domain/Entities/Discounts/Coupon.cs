using Store.Domain.Common;

namespace Store.Domain.Entities.Promotions;

public class Coupon : Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Code { get; set; }
}


