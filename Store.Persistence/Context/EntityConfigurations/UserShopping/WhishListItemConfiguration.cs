using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.UserShopping;

namespace Store.Dal.Context.Config.UserShopping;

internal class WhishListItemConfiguration : IEntityTypeConfiguration<WishListItem>
{
    public void Configure(EntityTypeBuilder<WishListItem> builder)
    {
        builder.HasKey(x => new { x.WishListId, x.ProductInventoryId });

        builder.HasOne<WishList>()
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.WishListId);

        builder.HasOne(x => x.ProductInventory)
            .WithMany()
            .HasForeignKey(x => x.ProductInventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.ProductInventoryId);

        builder.ToTable("WishListItems");
    }
}
