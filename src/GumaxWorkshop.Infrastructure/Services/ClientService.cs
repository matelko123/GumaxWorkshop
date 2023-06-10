using GumaxWorkshop.Application.Data;
using GumaxWorkshop.Domain.Entities;
using GumaxWorkshop.Domain.Interfaces.Services;
using GumaxWorkshop.Domain.ValueObjects;
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
        return await _applicationDbContext.Clients.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Client?> GetClientByNIPAsync(NIP nip, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Client?> GetClientByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Client> CreateClientAsync(Client newClient, CancellationToken cancellationToken)
    {
        var existingClientWithSamePhoneNumber = await _applicationDbContext
            .Clients
            .AnyAsync(c => c.PhoneNumber == newClient.PhoneNumber, cancellationToken);

        if (existingClientWithSamePhoneNumber)
        {
            throw new Exception("Client with that phone number already exists.");
        }
        
        // TODO: Add Fluent Validation
        if (newClient.Type == ClientType.Company && newClient.NIP != null)
        {
            var existingCompanyWithSameNIP = await _applicationDbContext
                .Clients
                .AnyAsync(c => c.NIP == newClient.NIP, cancellationToken: cancellationToken);
            if (existingCompanyWithSameNIP)
            {
                throw new Exception("Client with that NIP already exists.");
            }
        }
        
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