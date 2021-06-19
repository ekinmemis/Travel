namespace Travel.Models
{
    /// <summary>
    /// Defines the <see cref="IPageableModel" />.
    /// </summary>
    public interface IPageableModel
    {
        /// <summary>
        /// Gets the PageIndex.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Gets the PageNumber.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the PageSize.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the TotalItems.
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// Gets the TotalPages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the FirstItem.
        /// </summary>
        int FirstItem { get; }

        /// <summary>
        /// Gets the LastItem.
        /// </summary>
        int LastItem { get; }

        /// <summary>
        /// Gets a value indicating whether HasPreviousPage.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Gets a value indicating whether HasNextPage.
        /// </summary>
        bool HasNextPage { get; }
    }

    /// <summary>
    /// Defines the <see cref="IPagination{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IPagination<T> : IPageableModel
    {
    }
}
