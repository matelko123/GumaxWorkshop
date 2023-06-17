using GumaxWorkshop.API.Endpoints.Internal;
using GumaxWorkshop.Application.Clients.Commands.Create;
using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GumaxWorkshop.API.Endpoints;

public class ClientEndpoints : IEndpoints
{
    private const string ContentType = "application/json";
    private const string Tag = "Clients";
    private const string BaseRoute = "clients";

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(BaseRoute, async (
                [FromBody] CreateClientCommand command, ISender sender,
            CancellationToken cancellationToken) =>
        {
            var client = await sender.Send(command, cancellationToken);
            return Results.Ok(client);
            // return TypedResults.CreatedAtRoute(client, $"{BaseRoute}/id", new { id = client.Id});
        })
            .WithName("CreateClient")
            .WithTags(Tag)
            .Accepts<CreateClientCommand>(ContentType)
            .Produces<ClientResponse>(StatusCodes.Status200OK)
            .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest);
        }
}