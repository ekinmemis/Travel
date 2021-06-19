namespace Travel.Models
{
    using Core;

    using System;

    /// <summary>
    /// Defines the <see cref="BasePageableModel" />.
    /// </summary>
    public abstract class BasePageableModel : IPageableModel
    {
        /// <summary>
        /// The LoadPagedList.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="pagedList">The pagedList<see cref="IPagedList{T}"/>.</param>
        public virtual void LoadPagedList<T>(IPagedList<T> pagedList)
        {
            FirstItem = (pagedList.PageIndex * pagedList.PageSize) + 1;
            HasNextPage = pagedList.HasNextPage;
            HasPreviousPage = pagedList.HasPreviousPage;
            LastItem = Math.Min(pagedList.TotalCount, ((pagedList.PageIndex * pagedList.PageSize) + pagedList.PageSize));
            PageNumber = pagedList.PageIndex + 1;
            PageSize = pagedList.PageSize;
            TotalItems = pagedList.TotalCount;
            TotalPages = pagedList.TotalPages;
        }

        /// <summary>
        /// Gets or sets the FirstItem.
        /// </summary>
        public int FirstItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasNextPage.
        /// </summary>
        public bool HasNextPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasPreviousPage.
        /// </summary>
        public bool HasPreviousPage { get; set; }

        /// <summary>
        /// Gets or sets the LastItem.
        /// </summary>
        public int LastItem { get; set; }

        /// <summary>
        /// Gets the PageIndex.
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (PageNumber > 0)
                    return PageNumber - 1;

                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the PageNumber.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the PageSize.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the TotalItems.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the TotalPages.
        /// </summary>
        public int TotalPages { get; set; }
    }
}
