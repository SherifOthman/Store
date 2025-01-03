namespace Store.Domain.Entities.Users;

public class UserRole
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime AssignedOn { get; set; }

    public UserRole()
    {
        AssignedOn = DateTime.UtcNow;
    }
}
