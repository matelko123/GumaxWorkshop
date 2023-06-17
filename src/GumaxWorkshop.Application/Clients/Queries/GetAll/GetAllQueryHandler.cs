using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Application.Common.PaginatedList;
using GumaxWorkshop.Application.Data;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Queries.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, PaginatedList<ClientResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<ClientResponse>> Handle(
        GetAllQuery request, CancellationToken cancellationToken)
    {
        var results = await _context
            .Clients
            .MapToResponse()
            .PaginatedListAsync(request, cancellationToken);

        return results;
    }
}