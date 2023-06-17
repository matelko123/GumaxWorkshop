using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Domain.Interfaces.Services;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientResponse>
{
    private readonly IClientService _clientService;

    public CreateClientCommandHandler(
        IClientService clientService)
    {
        _clientService = clientService;
    }

    public async Task<ClientResponse> Handle(
        CreateClientCommand request, 
        CancellationToken cancellationToken)
    {
        var newClient = request.MapToClient();
        await _clientService.CreateClientAsync(newClient, cancellationToken);
        return newClient.MapToResponse();
    }
}