﻿using Store.Domain.Common;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Users;

namespace Store.Domain.Entities.Products;

public class Review : Entity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public string? Comment { get; set; }
    public byte Rating { get; set; }
    public DateTime CreatedOn { get; private set; }


    public Review()
    {
        CreatedOn = DateTime.UtcNow;
    }

}
