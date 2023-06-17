using GumaxWorkshop.Application.Clients.Commands.Create;
using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Domain.Entities;

namespace GumaxWorkshop.Application.Clients;

public static class ClientMapper
{
    public static Client MapToClient(this CreateClientCommand command)
    {
        return new Client
        {
            Id = Guid.NewGuid(),
            Type = command.Type,
            PhoneNumber = command.PhoneNumber,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Address = command.Address,
            CompanyName = command.CompanyName,
            NIP = command.NIP
        };
    }

    public static ClientResponse MapToResponse(this Client client)
    {
        return new ClientResponse(
            client.Id,
            client.Type,
            client.PhoneNumber,
            client.FirstName,
            client.LastName,
            client.Address,
            client.CompanyName,
            client.NIP);
    }

    public static IQueryable<ClientResponse> MapToResponse(this IEnumerable<Client> clients)
    {
        return clients.Select(MapToResponse).AsQueryable();
    }
}