using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.Context.Config.Products;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.IsActive);

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasOne<Category>()
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.RootCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => x.IsActive);

        builder.HasIndex(x => x.RootCategoryId);

        builder.ToTable("Categories");
    }
}
