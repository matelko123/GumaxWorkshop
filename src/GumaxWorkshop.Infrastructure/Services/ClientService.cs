using GumaxWorkshop.Application.Data;
using GumaxWorkshop.Domain.Entities;
using GumaxWorkshop.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace GumaxWorkshop.Infrastructure.Services;

public class ClientService : IClientService
{
    private readonly IApplicationDbContext _applicationDbContext;

    public ClientService(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Clients
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Clients
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Client?> GetClientByNIPAsync(string nip, CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Clients
            .SingleOrDefaultAsync(x => x.NIP == nip, cancellationToken);
    }

    public async Task<Client?> GetClientByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Clients
            .SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber, cancellationToken);
    }

    public async Task<Client> CreateClientAsync(Client newClient, CancellationToken cancellationToken)
    {
        await _applicationDbContext.Clients.AddAsync(newClient, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newClient;
    }

    public async Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}