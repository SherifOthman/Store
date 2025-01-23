using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Common;
using Store.Domain.Entities.Users;


namespace Store.Infrastructure.Context.EntityConfigurations.Common;
internal abstract class TrackedEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : TrackedEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // Common properties for auditable fields

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(x => x.CreatedByUserId);
        builder.HasIndex(x => x.LastModifiedByUserId);

    }
}
