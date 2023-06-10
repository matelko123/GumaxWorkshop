using GumaxWorkshop.Domain.Entities;
using GumaxWorkshop.Domain.Interfaces.Services;
using MapsterMapper;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public CreateClientCommandHandler(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

    public async Task<CreateClientResponse> Handle(
        CreateClientCommand request, 
        CancellationToken cancellationToken)
    {
        var newClient = _mapper.Map<Client>(request);
        await _clientService.CreateClientAsync(newClient, cancellationToken);
        return _mapper.Map<CreateClientResponse>(newClient);
    }
}