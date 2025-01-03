using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;
using Store.Domain.Entities.UserShopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
