using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Application.Contracts.Infrastructure;
using Store.Domain.Entities.Users;


namespace Store.Dal.Context.Config.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    private readonly IPasswordHasher? _passwordHasher;

    public UserConfiguration()
    {
        
    }

    public UserConfiguration(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(x => x.FirstName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
           .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(50);

        builder.Property(x => x.PasswordHashed)
            .HasMaxLength(128);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(11);

        builder.HasQueryFilter(x=> !x.IsDeleted);

        builder.HasData(GetInitialData());

        builder.ToTable("Users");
    }

    private  List<User> GetInitialData()
    {
        string password = "123";

        return new List<User>
        {
            new User {
                Id = 1,
                FirstName = "Saman",
                LastName = "Kaream",
                Email = "admin@example.com",
                PasswordHashed = _passwordHasher?.HashPassword(password) ?? password,
                CreatedOn = new DateTime(2025,1,2,0,0,0, DateTimeKind.Utc)
            },
             new User {
                Id = 2,
                FirstName = "Sherif",
                LastName = "Ali",
                Email = "customer@example.com",
                PasswordHashed = _passwordHasher?.HashPassword(password) ?? password,
                CreatedOn = new DateTime(2025,1,2,0,0,0, DateTimeKind.Utc)
            }
        };

    }
}
