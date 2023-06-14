using GumaxWorkshop.Domain.Entities;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public record CreateClientResponse (
    Guid Id,
    ClientType Type,
    string PhoneNumber,
    string? FirstName,
    string? LastName,
    string? Address,
    string? CompanyName,
    string? NIP
);