using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.Context.EntityConfigurations.Orders;

internal class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Method)
            .HasConversion<int>();

        builder.Property(x => x.Status)
           .HasConversion<int>();

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Shipping)
            .HasForeignKey<Shipping>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x=>x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.OrderId)
            .IsUnique();

        builder.HasQueryFilter(x => !x.Order.User.IsDeleted);

        builder.ToTable("Shippings");

    }
}
