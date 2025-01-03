using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;

namespace Store.Dal.Context.EntityConfigurations.Products;

internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Comment)
            .HasMaxLength(1000);

        builder.HasOne(x=>x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x=>x.Product)
            .WithMany(x=>x.Reviews)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.ProductId);

        builder.ToTable("Reviews");
    }
}
