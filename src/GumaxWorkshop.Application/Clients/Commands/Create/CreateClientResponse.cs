using GumaxWorkshop.Domain.Entities;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed class CreateClientResponse
{
    public Guid Id { get; init; }
    public ClientType Type { get; init; }
    public string PhoneNumber { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Address { get; init; }
    public string? CompanyName { get; init; }
    public string? NIP { get; init; }
}