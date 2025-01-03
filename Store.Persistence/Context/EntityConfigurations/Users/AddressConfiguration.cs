using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities.Users;

namespace Store.Dal.Context.Config.Users;

internal class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.AddressDetails)
            .HasMaxLength(500);

        builder.HasOne<User>()
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.CityId);


        builder.ToTable("Addresses");
    }
}
