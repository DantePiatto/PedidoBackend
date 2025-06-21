
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Delivery.Application.Abstractions.Behaviors;

namespace Delivery.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(configuration => 
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

        });

        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        return services;
    }
}