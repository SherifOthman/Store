using Store.Domain.Common;
using System.Net.Mail;
using System.Linq;

namespace Store.Domain.Entities.Users;

public sealed class User : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public bool IsDeleted { get; private set; }

    private readonly HashSet<Role> _roles = new();
    public IReadOnlyCollection<Role> Roles => _roles;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public static User Create(string firstName, string lastName, string email, string hashedPassword, string phoneNumber)
    {
        ValidateInputs(firstName, lastName, email, hashedPassword, phoneNumber);

        return new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            HashedPassword = hashedPassword,
            PhoneNumber = phoneNumber,
            CreatedOn = DateTime.UtcNow,
            IsDeleted = false
        };
    }

    public void AddRole(Role role) => _roles.Add(role);
    public void RemoveRole(Role role) => _roles.Remove(role);

    public void ChangeName(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        FirstName = firstName;
        LastName = lastName;
    }

    public void ChangeEmail(string email)
    {
        EnsureValidEmail(email);
        Email = email;
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        EnsureValidPhoneNumber(phoneNumber);
        PhoneNumber = phoneNumber;
    }

    public void MarkAsDeleted() => IsDeleted = true;

    private static void ValidateInputs(string firstName, string lastName, string email, string hashedPassword, string phoneNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentException.ThrowIfNullOrWhiteSpace(hashedPassword, nameof(hashedPassword));
        EnsureValidEmail(email);
        EnsureValidPhoneNumber(phoneNumber);
    }

    private static void EnsureValidEmail(string email)
    {
        try
        {
            _ = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Invalid email address format.", nameof(email));
        }
    }

    private static void EnsureValidPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
        {
            throw new ArgumentException("Phone number must be 11 digits long and contain only numbers.", nameof(phoneNumber));
        }
    }
}
