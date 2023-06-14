using GumaxWorkshop.Domain.Entities;

namespace GumaxWorkshop.Domain.Interfaces.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken);
    Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Client?> GetClientByNIPAsync(string nip, CancellationToken cancellationToken);
    Task<Client?> GetClientByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);
    
    
    Task<Client> CreateClientAsync(Client newClient, CancellationToken cancellationToken);
    Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken);
    Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken);
}