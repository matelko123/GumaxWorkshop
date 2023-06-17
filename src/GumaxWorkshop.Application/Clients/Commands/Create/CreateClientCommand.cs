using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Domain.Entities;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed record CreateClientCommand(
    ClientType Type,
    string PhoneNumber,
    string? FirstName,
    string? LastName,
    string? Address,
    string? CompanyName,
    string? NIP
) : IRequest<ClientResponse>;