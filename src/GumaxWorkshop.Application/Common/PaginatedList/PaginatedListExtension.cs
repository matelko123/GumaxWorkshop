using Microsoft.EntityFrameworkCore;

namespace GumaxWorkshop.Application.Common.PaginatedList;

public static class PaginatedListExtension
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable,
        PaginatedListRequest options,
        CancellationToken cancellationToken)
        where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), options, cancellationToken);
}