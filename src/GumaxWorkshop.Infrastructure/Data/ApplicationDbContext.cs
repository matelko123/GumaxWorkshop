using GumaxWorkshop.Application.Data;
using GumaxWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GumaxWorkshop.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Client> Clients { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}