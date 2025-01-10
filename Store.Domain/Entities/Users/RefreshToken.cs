using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users;
public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOn { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime CreatedOn { get; private set; }
    public string? CreatedByIp { get; set; }
    public string? RevokedByIp { get; set; }


    public RefreshToken()
    {
        CreatedOn = DateTime.UtcNow;
        IsUsed = false;
        IsRevoked = false;
    }

}
