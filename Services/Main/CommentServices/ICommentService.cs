using Core;
using Core.Domain.Main;

namespace Services.CommentServices
{
    /// <summary>
    /// Defines the <see cref="ICommentService" />.
    /// </summary>
    public interface ICommentService
    {
        #region Methods

        /// <summary>
        /// The GetAllComments.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Comment}"/>.</returns>
        IPagedList<Comment> GetAllComments(string title = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetCommentById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Comment"/>.</returns>
        Comment GetCommentById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="comment">The comment<see cref="Comment"/>.</param>
        void Insert(Comment comment);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="comment">The comment<see cref="Comment"/>.</param>
        void Update(Comment comment);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);

        #endregion
    }
}
