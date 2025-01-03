using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Orders;

public class OrderItem
{
    public int OrderId { get; set; }
    public int ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
