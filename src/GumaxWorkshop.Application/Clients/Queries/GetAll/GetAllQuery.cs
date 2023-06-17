using GumaxWorkshop.Application.Clients.DTOs;
using GumaxWorkshop.Application.Common.PaginatedList;
using MediatR;

namespace GumaxWorkshop.Application.Clients.Queries.GetAll;

public class GetAllQuery 
    : PaginatedListRequest, IRequest<PaginatedList<ClientResponse>>
{
}