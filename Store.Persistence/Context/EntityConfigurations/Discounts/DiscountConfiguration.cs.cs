
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Promotions;

namespace Store.Persistence.Context.EntityConfigurations.Discounts;
public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(50);


        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasOne(x => x.ProductInventory)
            .WithOne()
            .HasForeignKey<Discount>(x => x.ProductInventoryId);

        builder.HasOne(x => x.Coupon)
            .WithOne()
            .HasForeignKey<Discount>(x => x.CouponId);

        builder.HasOne(x => x.DiscountType)
            .WithMany()
            .HasForeignKey(x => x.DiscountTypeId);

        builder.HasIndex(x => x.DiscountTypeId);

      //  builder.HasQueryFilter(x => !x.ProductInventory.CreatedBy.IsDeleted);

        builder.ToTable("Discounts");

    }
}
