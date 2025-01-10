using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;
using Store.Infrastructure.Context.EntityConfigurations.Common;

namespace Store.Dal.Context.Config.Products;

internal class ProductConfiguraiton : AduitableEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(500);

        builder.Property(x => x.Description)
            .HasMaxLength(-1);

        builder.HasOne(x => x.Brand)
            .WithMany()
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.BrandId);
        builder.HasIndex(x => x.CategoryId);

        builder.HasQueryFilter(x => !x.CreatedBy.IsDeleted);

        builder.ToTable("Products");
    }
}
