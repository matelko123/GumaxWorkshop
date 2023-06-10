using GumaxWorkshop.Domain.Entities;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed class CreateClientCommand : IRequest<CreateClientResponse>
{
    public ClientType Type { get; set; }
    public string PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? CompanyName { get; set; }
    public string? NIP { get; set; }
}