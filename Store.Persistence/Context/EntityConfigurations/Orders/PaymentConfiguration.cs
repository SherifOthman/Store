using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Orders;

namespace Store.Dal.Context.EntityConfigurations.Orders;

internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Amount)
            .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Method)
            .HasConversion<int>();

        builder.Property(x => x.Status)
            .HasConversion<int>();

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Payment)
            .HasForeignKey<Payment>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.OrderId)
            .IsUnique();

        builder.HasQueryFilter(builder => !builder.Order.User.IsDeleted);

        builder.ToTable("Payments");
    }

 
}
