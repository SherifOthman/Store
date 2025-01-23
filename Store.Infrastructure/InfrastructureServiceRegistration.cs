using Microsoft.Extensions.DependencyInjection;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Application.Contracts.Infrastructure.Services;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Infrastructure.Authentication;
using Store.Infrastructure.Services;
using Store.Infrastructure.Utilities;

namespace Store.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
