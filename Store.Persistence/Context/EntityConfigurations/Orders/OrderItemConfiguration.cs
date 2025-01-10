using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Orders;

namespace Store.Dal.Context.EntityConfigurations.Orders;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => new { x.OrderId, x.ProductInventoryId });

        builder.Property(x => x.Price)
            .HasColumnType("decimal(10,2)");

        builder.HasOne<Order>()
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x=>x.ProductInventory)
            .WithMany()
            .HasForeignKey(x=>x.ProductInventoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProductInventoryId);

        builder.HasQueryFilter(x => !x.ProductInventory.CreatedBy.IsDeleted);

        builder.ToTable("OrderItems");
    }
}
