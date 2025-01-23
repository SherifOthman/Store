using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Behaviors;
using Store.Application.PipelineBehaviors;


namespace Store.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
        cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddMapster();
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

     //   services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviorForResult<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipeLineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        return services;
    }
}
