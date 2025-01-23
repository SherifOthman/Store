using System;

namespace Store.Domain.Common;

public abstract class TrackedEntity
{
    public Guid CreatedByUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModifiedByUserId
    {
        get
        {
            return field;
        }
        set
        {
            field = value;
            LastModifiedOn = DateTime.UtcNow;
        }
    }
    public DateTime? LastModifiedOn { get; private set; }

}
