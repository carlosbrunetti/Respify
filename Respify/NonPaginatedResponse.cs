using Respify.Interfaces;

namespace Respify;
public class NonPaginatedResponse<T>() : INonPaginatedResponse<T>
{
    public T Items { get; set; } 
    public int Total { get; set; }
}