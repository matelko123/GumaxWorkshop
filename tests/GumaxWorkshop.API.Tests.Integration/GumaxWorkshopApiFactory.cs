using GumaxWorkshop.Application.Data;
using GumaxWorkshop.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GumaxWorkshop.API.Tests.Integration;

public class GumaxWorkshopApiFactory : WebApplicationFactory<IAPIMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            collection.RemoveAll(typeof(IApplicationDbContext));
            
            collection.AddDbContext<IApplicationDbContext,ApplicationDbContext>(options =>
            {
                options.UseSqlite("DataSource=file:inmem?mode=memory&cache=shared");
            });
            
            var sp = collection.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();
        });
    }
}