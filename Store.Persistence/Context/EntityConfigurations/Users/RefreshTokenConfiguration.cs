using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;

namespace Store.Persistence.Context.EntityConfigurations.Users;
internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Token)
            .HasMaxLength(250);

        builder.Property(x => x.CreatedByIp)
            .HasMaxLength(50);

        builder.Property(x => x.RevokedByIp)
            .HasMaxLength(50);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.UserId);

        builder.HasQueryFilter(x => !x.User.IsDeleted);

        builder.ToTable("RefreshTokens");
    }
}
