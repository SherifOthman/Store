
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Store.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
        cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
