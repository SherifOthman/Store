using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Promotions;

public class Discount
{
    public int Id { get; set; }
    public int ProductInventoryId { get; set; }
    public required string Name { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
    public int DiscountValue { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsActive { get; set; }
    public int DiscountTypeId { get; set; }
    public DiscountType DiscountType { get; set; } = null!;
    public int? CouponId { get; set; }
    public Coupon? Coupon { get; set; } 

}


