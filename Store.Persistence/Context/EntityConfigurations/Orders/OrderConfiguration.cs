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

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);


        builder.Property(x => x.TotalAmount)
           .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Status)
            .HasConversion<int>();

        builder.HasOne(x=>x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.UserId);

        builder.HasQueryFilter(x => !x.User.IsDeleted);

        builder.ToTable("Orders");
    }
}
