using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;
using Store.Infrastructure.Context.EntityConfigurations.Common;

namespace Store.Dal.Context.Config.Products;

internal class ProductInventoryConfiguraiton : AduitableEntityConfiguration<ProductInventory>
{
    public override void Configure(EntityTypeBuilder<ProductInventory> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => x.Id);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(10,2)");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Inventories)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasIndex(x => x.ProductId);

        builder.HasQueryFilter(x => !x.CreatedBy.IsDeleted);


        builder.ToTable("ProductInventories");
    }
}
