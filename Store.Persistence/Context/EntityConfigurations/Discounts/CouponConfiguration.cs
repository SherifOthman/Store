
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Promotions;

namespace Store.Persistence.Context.EntityConfigurations.Discounts;
public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.Property(x => x.Code)
            .HasMaxLength(30);

        builder.ToTable("Coupons");
    }
}
