using GumaxWorkshop.Domain.Interfaces.Services;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
{
    private readonly IClientService _clientService;

    public CreateClientCommandHandler(
        IClientService clientService)
    {
        _clientService = clientService;
    }

    public async Task<CreateClientResponse> Handle(
        CreateClientCommand request, 
        CancellationToken cancellationToken)
    {
        var newClient = request.MapToClient();
        await _clientService.CreateClientAsync(newClient, cancellationToken);
        return newClient.MapToResponse();
    }
}