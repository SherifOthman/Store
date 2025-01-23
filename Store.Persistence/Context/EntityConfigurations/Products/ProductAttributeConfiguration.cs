using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;

namespace Store.Dal.Context.Config.Products;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        builder.Property(x => x.DataType)
            .HasConversion<int>();

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.ToTable("ProductAttributes");
    }
}
