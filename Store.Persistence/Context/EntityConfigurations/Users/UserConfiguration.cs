using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Domain.Entities.Users;


namespace Store.Dal.Context.Config.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(x => x.FirstName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
           .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(50);

        builder.Property(x => x.HashedPassword)
            .HasMaxLength(128);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(11);

        //builder.Property(x => x.Roles)
        //    .UsePropertyAccessMode(PropertyAccessMode.Field);


        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.ToTable("Users");
    }
}
