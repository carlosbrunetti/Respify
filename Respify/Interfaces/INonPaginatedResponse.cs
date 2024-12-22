namespace Respify.Interfaces;

public interface INonPaginatedResponse<T>
{
    public T Items { get; set; }
    public int Total { get; set; }
}