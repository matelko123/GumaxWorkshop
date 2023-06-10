using GumaxWorkshop.Domain.Entities;
using GumaxWorkshop.Domain.ValueObjects;
using Mapster;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public class CreateClientCommandMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateClientCommand, Client>()
            .Map(c => c.NIP, s => new NIP(s.NIP));

        config.NewConfig<Client, CreateClientResponse>()
            .Map(c => c.NIP, s => s.NIP.Value);
    }
}