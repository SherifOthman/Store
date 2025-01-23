using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;
using Store.Domain.FixedValues;


namespace Store.Dal.Context.EntityConfigurations.Users;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        builder.HasMany<User>()
            .WithMany(u => u.Roles)
            .UsingEntity<UserRole>();

        builder.ToTable("Roles");
    }

}
