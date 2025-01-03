
using Store.Domain.Entities.Users;

namespace Store.Domain.Common;
public class TrackedEntity
{
    public int CreatedByUserId { get; set; }
    public User CreatedBy { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public int? LastModifiedByUserId { get; set; }
    public User? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }


    public TrackedEntity()
    {
        CreatedOn = DateTime.UtcNow;
    }
}
