using Core;
using Core.Domain.Main;
using Data.EfRepository;
using System.Linq;

namespace Services.BlogServices
{
    /// <summary>
    /// Defines the <see cref="BlogService" />.
    /// </summary>
    public class BlogService : IBlogService
    {
        /// <summary>
        /// Defines the _blogRepository.
        /// </summary>
        private readonly IRepository<Blog> _blogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogService"/> class.
        /// </summary>
        public BlogService()
        {
            _blogRepository = new Repository<Blog>();
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var blog = _blogRepository.GetById(id);

            _blogRepository.Delete(blog);
        }

        /// <summary>
        /// The GetAllBlogs.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Blog}"/>.</returns>
        public IPagedList<Blog> GetAllBlogs(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _blogRepository.Table.Where(f => f.Deleted != true);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            query = query.OrderBy(o => o.Id);

            var blogs = new PagedList<Blog>(query, pageIndex, pageSize);

            return blogs;
        }

        /// <summary>
        /// The GetBlogById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Blog"/>.</returns>
        public Blog GetBlogById(int id)
        {
            return _blogRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="blog">The blog<see cref="Blog"/>.</param>
        public void Insert(Blog blog)
        {
            _blogRepository.Insert(blog);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="blog">The blog<see cref="Blog"/>.</param>
        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
        }
    }
}
