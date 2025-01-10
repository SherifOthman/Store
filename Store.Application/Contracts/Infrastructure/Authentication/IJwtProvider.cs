using Store.Application.Models;
using Store.Domain.Entities.Users;

namespace Store.Application.Contracts.Infrastructure.Authentication;
public interface IJwtProvider
{
    TokenVm GenerateAccessToken(User user);
    TokenVm GenerateRefreshToken();

}
