using GumaxWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GumaxWorkshop.Application.Data;

public interface IApplicationDbContext
{
    public DbSet<Client> Clients { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}