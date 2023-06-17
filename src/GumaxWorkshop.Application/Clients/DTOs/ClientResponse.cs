using GumaxWorkshop.Domain.Entities;

namespace GumaxWorkshop.Application.Clients.DTOs;

public record ClientResponse (
    Guid Id,
    ClientType Type,
    string PhoneNumber,
    string? FirstName,
    string? LastName,
    string? Address,
    string? CompanyName,
    string? NIP
);