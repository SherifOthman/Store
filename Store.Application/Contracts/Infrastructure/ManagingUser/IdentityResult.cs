namespace Store.Application.Contracts.Infrastructure.ManagingUser;
public class IdentityResult
{
    public bool Succceeded { get; private set; } = true;
    public string? Error { get; private set; }

    public static IdentityResult Success()
    {
        return new IdentityResult();
    }

    public static IdentityResult Failed(string error)
    {
        return new IdentityResult
        {
            Succceeded = false,
            Error = error
        };
    }

    public static IdentityResult Failed()
    {
        return new IdentityResult()
        {
            Succceeded = false
        };
    }
}
