using Respify.Interfaces;

namespace Respify;
public class NonPaginatedResponse<T>() : INonPaginatedResponse<T>
{
    public NonPaginatedResponse(T items, int total) : this()
    {
        Items = items;
        Count = total;
    }
    public T Items { get; set; } 
    public int Count { get; set; }
}