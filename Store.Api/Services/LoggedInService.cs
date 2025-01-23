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

    public Guid UserId
    {
        get
        {
            var indentifer = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(indentifer, out Guid userId))
            {
                throw new InvalidOperationException("User identifier is missing or invalid.");
            }

            return userId;
        }
    }

}