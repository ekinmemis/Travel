using System.Collections.Generic;

namespace Core
{
    public interface IPagedList<TEntity> : IList<TEntity>
    {
        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}
