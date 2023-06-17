namespace GumaxWorkshop.Application.Common.PaginatedList;

public abstract class PaginatedListRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
    public string? SortField { get; set; }
    public SortOrder? SortOrder { get; set; } = PaginatedList.SortOrder.Unsorted;
}

public enum SortOrder
{
    Unsorted,
    Ascending,
    Descending
}