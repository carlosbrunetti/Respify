namespace Respify.Interfaces;

/// <summary>
/// Interface for a paginated response.
/// </summary>
/// <typeparam name="T">The type of the items in the response.</typeparam>
public interface IPaginatedResponse<T>
{
    /// <summary>
    /// Gets or sets the items in the response.
    /// </summary>
    public T Items { get; set; }

    /// <summary>
    /// Gets or sets the count of items in the response.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the size of the page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the field by which the items are ordered.
    /// </summary>
    public string OrderBy { get; set; }

    /// <summary>
    /// Gets or sets the field by which the items are sorted.
    /// </summary>
    public string SortBy { get; set; }
}