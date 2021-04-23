using Core;
using Core.Domain.Main;
using Data.EfRepository;
using System.Linq;

namespace Services.CommentServices
{
    /// <summary>
    /// Defines the <see cref="CommentService" />.
    /// </summary>
    public class CommentService : ICommentService
    {
        #region Fields

        /// <summary>
        /// Defines the _commentRepository.
        /// </summary>
        private readonly IRepository<Comment> _commentRepository;

        #endregion

        #region Constructor
        public CommentService()
        {
            _commentRepository = new Repository<Comment>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// The GetAllComments.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Comment}"/>.</returns>
        public IPagedList<Comment> GetAllComments(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _commentRepository.Table;

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Subject.Contains(title));

            query = query.OrderBy(o => o.Id);

            var comments = new PagedList<Comment>(query, pageIndex, pageSize);

            return comments;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var comment = _commentRepository.GetById(id);

            _commentRepository.Delete(comment);
        }

        /// <summary>
        /// The GetCommentById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Comment"/>.</returns>
        public Comment GetCommentById(int id)
        {
            return _commentRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="comment">The comment<see cref="Comment"/>.</param>
        public void Insert(Comment comment)
        {
            _commentRepository.Insert(comment);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="comment">The comment<see cref="Comment"/>.</param>
        public void Update(Comment comment)
        {
            _commentRepository.Update(comment);
        }
        #endregion



    }
}
