using System.Net;
using FluentAssertions;
using GumaxWorkshop.Application.Clients.Commands.Create;
using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Domain.Entities;
using Xunit;

namespace GumaxWorkshop.API.Tests.Integration.Clients;

public class CreateEndpointTests : IClassFixture<GumaxWorkshopApiFactory>, IAsyncLifetime
{
    private readonly GumaxWorkshopApiFactory _factory;

    public CreateEndpointTests(GumaxWorkshopApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CreateClient_CreatesIndividualClient_WhenDataIsCorrect()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var requestBody = CreateSampleIndividualClientCommand();
        
        // Act
        var result = await httpClient.PostAsJsonAsync("/clients", requestBody);
        var createdClient = await result.Content.ReadFromJsonAsync<ClientResponse>();

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        createdClient.Should().BeEquivalentTo(requestBody);
        // result.Headers.Location.Should().Be($"{httpClient.BaseAddress}clients/{createdClient!.Id}");
    }

    [Fact]
    public async Task CreateClient_CreatesCompanyClient_WhenDataIsCorrect()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var requestBody = CreateSampleCompanyClientCommand();
        
        // Act
        var result = await httpClient.PostAsJsonAsync("/clients", requestBody);
        var createdClient = await result.Content.ReadFromJsonAsync<ClientResponse>();

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        createdClient.Should().BeEquivalentTo(requestBody);
        // result.Headers.Location.Should().Be($"{httpClient.BaseAddress}clients/{createdClient!.Id}");
    }
    
    
    
    private static CreateClientCommand CreateSampleIndividualClientCommand(string? phoneNumber = null)
    {
        return new CreateClientCommand(
            ClientType.Individual,
            phoneNumber ?? GeneratePhoneNumber(),
            "John",
            "Doe",
            "1234 Street Name, City, State, ZIP",
            null,
            null
        );
    }
    
    private static CreateClientCommand CreateSampleCompanyClientCommand(string? phoneNumber = null, string? nip = null)
    {
        return new CreateClientCommand(
            ClientType.Company,
            phoneNumber ?? GeneratePhoneNumber(),
            null,
            null,
            "1234 Street Name, City, State, ZIP",
            "Company Name",
            nip ?? GenerateNIP()
        );
    }

    private static string GeneratePhoneNumber() 
        => Random.Shared.Next(100000000, 999999999).ToString();

    private static string GenerateNIP()
        => $"{Random.Shared.Next(100, 999)}-{Random.Shared.Next(100, 999)}-{Random.Shared.Next(10, 99)}-{Random.Shared.Next(10, 99)}";
    
    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => Task.CompletedTask;
}