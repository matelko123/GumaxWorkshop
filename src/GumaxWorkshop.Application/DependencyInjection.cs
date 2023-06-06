using Microsoft.Extensions.DependencyInjection;

namespace GumaxWorkshop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<IApplicationMarker>();
        });

        return services;
    }
}