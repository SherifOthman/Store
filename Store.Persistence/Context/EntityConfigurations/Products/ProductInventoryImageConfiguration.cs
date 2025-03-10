﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;

namespace Store.Dal.Context.Config.Products;

internal class ProductInventoryImageConfiguration : IEntityTypeConfiguration<ProductInventoryImage>
{
    public void Configure(EntityTypeBuilder<ProductInventoryImage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.ImagePath)
            .HasMaxLength(255);

        builder.HasOne<ProductInventory>()
            .WithMany(x=>x.InventoryImages)
            .HasForeignKey(x=>x.ProductInventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x=>x.ProductInventoryId);

       // builder.HasQueryFilter(x => !x.productInventory.CreatedBy.IsDeleted);

        builder.ToTable("ProductInventoryImages");
    }
}
