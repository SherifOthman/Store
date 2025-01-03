using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Common;


namespace Store.Infrastructure.Context.EntityConfigurations.Common;
internal abstract class AduitableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : TrackedEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // Common properties for auditable fields

        builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.LastModifiedBy)
            .WithMany()
            .HasForeignKey(x => x.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(x => x.CreatedByUserId);
        builder.HasIndex(x => x.LastModifiedByUserId);

    }
}
