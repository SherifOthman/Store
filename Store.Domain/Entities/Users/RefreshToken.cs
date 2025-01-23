using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Users;
public class RefreshToken : Entity
{
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresOn { get; private set; }
    public bool IsRevoked { get; private set; }
    public DateTime CreatedOn { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private RefreshToken()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {

    }

    public static RefreshToken Create(Guid userId, string token, DateTime expiresOn)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(message: "UserId must be a valid GUID", nameof(userId));

        ArgumentException.ThrowIfNullOrWhiteSpace(token, nameof(token));

        if (expiresOn <= DateTime.Today)
            throw new ArgumentException("Date should be after today's date.");

        return new RefreshToken
        {
            UserId = userId,
            Token = token,
            CreatedOn = DateTime.UtcNow,
            ExpiresOn = expiresOn,
            IsRevoked = false
        };
    }

    public void Revoke()
    {
        IsRevoked = true;
    }

    public bool IsExpired()
    {
        return ExpiresOn <= DateTime.Today;
    }

    public bool IsValid()
    {
        return !(IsRevoked || IsExpired());
    }

}
