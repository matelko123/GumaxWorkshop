using GumaxWorkshop.Domain.Entities;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public static class CreateClientCommandMapper
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

    public static CreateClientResponse MapToResponse(this Client client)
    {
        return new CreateClientResponse(
            client.Id,
            client.Type,
            client.PhoneNumber,
            client.FirstName,
            client.LastName,
            client.Address,
            client.CompanyName,
            client.NIP);
    }
}