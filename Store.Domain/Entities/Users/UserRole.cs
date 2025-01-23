namespace Store.Domain.Entities.Users;

public sealed class UserRole
{
    public Guid UserId { get; }
    public Guid RoleId { get; }
    public DateTime AssignedIn { get; }

    private UserRole()
    {
        
    }

    public UserRole(Guid userId, Guid roleId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("UserId cannot be empty", nameof(userId));
        }

        if (roleId == Guid.Empty)
        {
            throw new ArgumentException("RoleId cannot be empty", nameof(roleId));
        }

        UserId = userId;
        RoleId = roleId;
        AssignedIn = DateTime.UtcNow;
    }
}
