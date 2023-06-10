using GumaxWorkshop.Application.Data;
using GumaxWorkshop.Domain.Interfaces.Services;
using GumaxWorkshop.Infrastructure.Data;
using GumaxWorkshop.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GumaxWorkshop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IClientService, ClientService>();
        
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Default"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }
}