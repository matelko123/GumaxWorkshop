using Microsoft.EntityFrameworkCore;

namespace GumaxWorkshop.Application.Common.PaginatedList;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    private PaginatedList(IReadOnlyCollection<T> items, int count, PaginatedListRequest options)
    {
        PageNumber = options.PageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)options.PageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    // TODO: Add ordering 
    public static async Task<PaginatedList<T>> CreateAsync(
        IQueryable<T> source, 
        PaginatedListRequest options,
        CancellationToken cancellationToken)
    {
        var count = await source.CountAsync(cancellationToken);
        var items = await source
            .Skip((options.PageNumber - 1) * options.PageSize)
            .Take(options.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<T>(items, count, options);
    }
}