using FluentValidation;
using GumaxWorkshop.Domain.Entities;
using GumaxWorkshop.Domain.Interfaces.Services;

namespace GumaxWorkshop.Application.Clients.Commands.Create;

public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    private readonly IClientService _clientService;
    
    public CreateClientCommandValidator(IClientService clientService)
    {
        _clientService = clientService;

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MustAsync(ValidatePhoneNumber).WithMessage("The client with that phone number already exists.");

        RuleFor(c => c.Type)
            .IsInEnum().WithMessage("Invalid client type.");

        When(c => c.Type == ClientType.Company, () =>
        {
            RuleFor(c => c.NIP)
                .NotNull().WithMessage("NIP is required for a company client.")
                .MinimumLength(5).WithMessage("Minimum length is 5 characters.")
                .MustAsync(ValidateNIP).WithMessage("The company with that NIP already exists.");

            RuleFor(c => c.CompanyName)
                .NotNull().WithMessage("Company name is required for a company client.")
                .MinimumLength(3).WithMessage("Minimum length is 3 characters.");
        });
    }

    private async Task<bool> ValidatePhoneNumber(CreateClientCommand client, string? phoneNumber, 
        CancellationToken cancellationToken)
    {
        var existingClient = await _clientService.GetClientByPhoneNumberAsync(phoneNumber!, cancellationToken);
        return existingClient is null;
    }
    
    private async Task<bool> ValidateNIP(CreateClientCommand client, string? nip, 
        CancellationToken cancellationToken)
    {
        var existingClient = await _clientService.GetClientByNIPAsync(nip, cancellationToken);
        return existingClient is null;
    }
}