using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;
using Store.Domain.Entities.UserShopping;

namespace Store.Dal.Context.Config.UserShopping;

internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
             .WithOne()
             .HasForeignKey<ShoppingCart>(x => x.UserId);

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.ToTable("ShoppingCarts");
    }
}
