using GumaxWorkshop.Domain.ValueObjects;

namespace GumaxWorkshop.Domain.Entities;

public class Client
{
    public required Guid Id { get; init; }
    public required ClientType Type { get; set; } = ClientType.Individual;
    public required string PhoneNumber { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public NIP? NIP { get; set; }
}
public enum ClientType
{
    Individual,
    Company
}