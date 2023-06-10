using FluentValidation;
using GumaxWorkshop.Application.Behaviors;
using Mapster;
using MapsterMapper;
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
        
        // Mapster
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(IApplicationMarker).Assembly);
        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();
        
        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}