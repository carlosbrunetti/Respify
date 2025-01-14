namespace Respify.Interfaces;

/// <summary>
/// Interface for a non-paginated response.
/// </summary>
/// <typeparam name="T">The type of the items in the response.</typeparam>
public interface INonPaginatedResponse<T>
{
    /// <summary>
    /// Gets or sets the items in the response.
    /// </summary>
    public T Items { get; set; }

    /// <summary>
    /// Gets or sets the count of items in the response.
    /// </summary>
    public int Count { get; set; }
}