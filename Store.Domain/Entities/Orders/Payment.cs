﻿using Store.Domain.Common;
using Store.Domain.Enums;

namespace Store.Domain.Entities.Orders;

public class Payment : Entity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaymentDate { get; private set; }


    public Payment()
    {
        PaymentDate = DateTime.UtcNow;
    }
}
