

using Microsoft.Extensions.DependencyInjection;
using Store.Application.Contracts.Infrastructure;
using Store.Application.Contracts.Infrastructure.Authentication;
using Store.Infrastructure.Authentication;

namespace Store.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
