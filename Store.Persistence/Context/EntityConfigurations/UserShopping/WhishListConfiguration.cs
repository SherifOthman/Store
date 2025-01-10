using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;
using Store.Domain.Entities.UserShopping;

namespace Store.Dal.Context.Config.UserShopping;

internal class WhishListConfiguration : IEntityTypeConfiguration<WishList>
{
    public void Configure(EntityTypeBuilder<WishList> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
             .WithOne()
             .HasForeignKey<WishList>(x => x.UserId);

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.ToTable("WishLisits");
    }
}
