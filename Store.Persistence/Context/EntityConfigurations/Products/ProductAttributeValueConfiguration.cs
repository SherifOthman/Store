using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;

namespace Store.Dal.Context.Config.Products;

internal class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
{
    public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
    {
        builder.HasKey(x => new { x.ProductInventoryId, x.AttributeId });

        builder.Property(x => x.value)
            .HasMaxLength(255);

        builder.HasOne(x => x.Attribute)
            .WithMany()
            .HasForeignKey(x => x.AttributeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ProductInventory)
            .WithMany(x => x.AttributeValues)
            .HasForeignKey(x => x.ProductInventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.AttributeId);

        builder.ToTable("ProductAttributeValues");
    }
}
