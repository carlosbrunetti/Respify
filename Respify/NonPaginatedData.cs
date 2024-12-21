using Respify.Interfaces;

namespace Respify;
public class NonPaginatedData<T>() : INonPaginatedData<T>
{
    public T Items { get; set; } 
    public int Total { get; set; }
}