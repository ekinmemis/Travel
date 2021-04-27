using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Defines the <see cref="PagedList{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    [Serializable]
    public partial class PagedList<TEntity> : List<TEntity>, IPagedList<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{TEntity}"/> class.
        /// </summary>
        /// <param name="source">The source<see cref="IQueryable{TEntity}"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="getOnlyTotalCount">The getOnlyTotalCount<see cref="bool"/>.</param>
        public PagedList(IQueryable<TEntity> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            var total = source.Count();

            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            if (getOnlyTotalCount)
                return;

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{TEntity}"/> class.
        /// </summary>
        /// <param name="source">The source<see cref="IList{TEntity}"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        public PagedList(IList<TEntity> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{TEntity}"/> class.
        /// </summary>
        /// <param name="source">The source<see cref="IEnumerable{TEntity}"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="totalCount">The totalCount<see cref="int"/>.</param>
        public PagedList(IEnumerable<TEntity> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        /// <summary>
        /// Gets the PageIndex.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Gets the PageSize.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Gets the TotalCount.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets the TotalPages.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Gets a value indicating whether HasPreviousPage.
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Gets a value indicating whether HasNextPage.
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
