namespace Respify.Interfaces;

public interface IPaginatedResponse<T>
{
    public T Items { get; set; }
    public int Count { get; set; }
    public int PageNumber { get; set; } 
    public int PageSize { get; set; } 
    public string OrderBy { get; set; }
    public string SortBy { get; set; }
}