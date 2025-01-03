
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;

namespace Store.Dal.Context.EntityConfigurations.Users;

internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => new { x.UserId, x.RoleId });

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(x => x.RoleId);

        builder.HasData(GetInitialData());

        builder.HasIndex(x => x.RoleId);

        builder.ToTable("UserRoles");
    }


    private List<UserRole> GetInitialData()
    {
        return new List<UserRole>()
        {
            new () {
                UserId = 1,
                RoleId = 1,
                AssignedOn = new DateTime(2025,1,2,0,0,0, DateTimeKind.Utc)
            },
            new () {
                UserId = 2,
                RoleId = 2 ,
                AssignedOn = new DateTime(2025,1,2,0,0,0, DateTimeKind.Utc)
            },
        };
    }

}
