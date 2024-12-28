using Respify.Interfaces;

namespace Respify;

/// <summary>
/// Represents a paginated response.
/// </summary>
/// <typeparam name="T">The type of the items in the response.</typeparam>
public class PaginatedResponse<T> : IPaginatedResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class.
    /// </summary>
    /// <param name="items">The items in the response.</param>
    /// <param name="total">The total count of items in the response.</param>
    /// <param name="page">The current page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="orderBy">The field by which the items are ordered.</param>
    /// <param name="sort">The field by which the items are sorted.</param>
    public PaginatedResponse(T items, int total, int page, int pageSize, string orderBy, string sort)
    {
        Items = items;
        Count = total;
        PageNumber = page;
        PageSize = pageSize;
        OrderBy = orderBy;
        SortBy = sort;
    }

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