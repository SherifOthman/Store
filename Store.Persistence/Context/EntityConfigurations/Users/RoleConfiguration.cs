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

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles)
            .UsingEntity<UserRole>();

        builder.ToTable("Roles");

        builder.HasData(GetInitialData());
    }

    private List<Role> GetInitialData()
    {
        return new List<Role>
        {
            new () {
                Id = 1,
                Name = RoleValues.Admin
            },
             new (){
                Id = 2,
                Name = RoleValues.Customer
            },
        };
    }
}
