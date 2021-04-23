using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Defines the <see cref="IPagedList{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public interface IPagedList<TEntity> : IList<TEntity>
    {
        #region Properties
       
        /// <summary>
        /// Gets the PageIndex.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Gets the PageSize.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the TotalCount.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the TotalPages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets a value indicating whether HasPreviousPage.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Gets a value indicating whether HasNextPage.
        /// </summary>
        bool HasNextPage { get; }

        #endregion
    }
}
