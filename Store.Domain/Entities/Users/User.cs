
namespace Store.Domain.Entities.Users;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string PasswordHashed { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool PhoneNumberConfirmed { get; set; }
    public DateTime? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsDeleted { get; set; }
    public List<Address>? Addresses { get; set; }
    public List<Role> Roles { get; set; } 

    public User()
    {
        CreatedOn = DateTime.UtcNow;
        IsDeleted = false;
        LockoutEnabled = false;
        EmailConfirmed = false;
        PhoneNumberConfirmed = false;
        AccessFailedCount = 0;
        Addresses = new List<Address>();
        Roles = new List<Role>();
    }

}
