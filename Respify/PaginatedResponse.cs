using Respify.Interfaces;

namespace Respify;

public class PaginatedResponse<T>: IPaginatedResponse<T>
{
    public PaginatedResponse (T items, int total, int page, int pageSize, string orderBy, string sort)
    {
        Items = items;
        Count = total;
        Page = page;
        PageSize = pageSize;
        OrderBy = orderBy;
        Sort = sort;
    }
    
    public T Items { get; set; } 
    public int Count { get; set; }
    public int Page { get; set; } 
    public int PageSize { get; set; }
    public string OrderBy { get; set; }
    public string Sort { get; set; }
}