using GumaxWorkshop.API.Endpoints.Internal;
using GumaxWorkshop.Application.Clients.Commands.Create;
using MediatR;

namespace GumaxWorkshop.API.Endpoints;

public class ClientEndpoints : IEndpoints
{
    private const string ContentType = "application/json";
    private const string Tag = "Clients";
    private const string BaseRoute = "clients";

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(BaseRoute, async (CreateClientCommand command, ISender sender,
            CancellationToken cancellationToken) =>
        {
            var client = await sender.Send(command, cancellationToken);
            return Results.Ok(client);
        })
            .WithName("CreateClient")
            .WithTags(Tag)
            .Accepts<CreateClientCommand>(ContentType)
            .Produces<CreateClientResponse>(StatusCodes.Status200OK);
    }
}