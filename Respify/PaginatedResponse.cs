using Respify.Interfaces;

namespace Respify;

public class PaginatedResponse<T>: IPaginatedResponse<T>
{
    public PaginatedResponse (T items, int total, int page, int pageSize, string orderBy, string sort)
    {
        Items = items;
        Count = total;
        PageNumber = page;
        PageSize = pageSize;
        OrderBy = orderBy;
        SortBy = sort;
    }
    
    public T Items { get; set; } 
    public int Count { get; set; }
    public int PageNumber { get; set; } 
    public int PageSize { get; set; }
    public string OrderBy { get; set; }
    public string SortBy { get; set; }
}