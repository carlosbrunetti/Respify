namespace Respify.Interfaces;

public interface IRespifyResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public List<string>? Errors { get; set; }
}