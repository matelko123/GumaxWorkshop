using FluentValidation;
using GumaxWorkshop.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GumaxWorkshop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<IApplicationMarker>();
        });
        
        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}