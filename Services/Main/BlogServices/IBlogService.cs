using Core;
using Core.Domain.Main;

namespace Services.BlogServices
{
    /// <summary>
    /// Defines the <see cref="IBlogService" />.
    /// </summary>
    public interface IBlogService
    {
        /// <summary>
        /// The GetAllBlogs.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Blog}"/>.</returns>
        IPagedList<Blog> GetAllBlogs(string title = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetBlogById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Blog"/>.</returns>
        Blog GetBlogById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="blog">The blog<see cref="Blog"/>.</param>
        void Insert(Blog blog);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="blog">The blog<see cref="Blog"/>.</param>
        void Update(Blog blog);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);
    }
}
