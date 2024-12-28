using Respify.Interfaces;

namespace Respify;

/// <summary>
/// Represents a non-paginated response.
/// </summary>
/// <typeparam name="T">The type of the items in the response.</typeparam>
public class NonPaginatedResponse<T> : INonPaginatedResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NonPaginatedResponse{T}"/> class.
    /// </summary>
    /// <param name="items">The items in the response.</param>
    /// <param name="total">The total count of items in the response.</param>
    public NonPaginatedResponse(T items, int total) => (Items, Count) = (items, total);
    
    /// <summary>
    /// Gets or sets the items in the response.
    /// </summary>
    public T Items { get; set; }

    /// <summary>
    /// Gets or sets the count of items in the response.
    /// </summary>
    public int Count { get; set; }
}