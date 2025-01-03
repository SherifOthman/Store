﻿namespace Store.Domain.Entities.Promotions;

public class Coupon
{
    public int Id { get; set; } 
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Code { get; set; }
}


