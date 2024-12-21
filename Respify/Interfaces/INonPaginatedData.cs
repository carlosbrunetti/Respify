namespace Respify.Interfaces;

public interface INonPaginatedData<T>
{
    public T Items { get; set; }
    public int Total { get; set; }
}