using Store.Api.Extentions;
using Store.Application.Contracts.Infrastructure.Authentication;
using System.Security.Claims;

namespace Store.Api.Services;

public class LoggedInService : ILoggedInService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public LoggedInService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public int UserId
    {
        get
        {
            var indentifer = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(indentifer, out int userId))
            {
                throw new InvalidOperationException("User identifier is missing or invalid.");
            }

            return userId;
        }
    }

    public string? IpAddress
    {
        get
        {
           return _contextAccessor.HttpContext?.GetClientApiAddress();
        }
    }
}