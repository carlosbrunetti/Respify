using Respify.Interfaces;

namespace Respify;

public class PaginatedData<T>: IPaginatedData<T>
{
    public T Items { get; set; } 
    public int Total { get; set; }
    public int Page { get; set; } 
    public int Size { get; set; }
    public string OrderBy { get; set; }
    public string Sort { get; set; }
}