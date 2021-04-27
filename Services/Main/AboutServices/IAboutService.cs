using Core;
using Core.Domain.Main;

namespace Services.AboutServices
{
    /// <summary>
    /// Defines the <see cref="IAboutService" />.
    /// </summary>
    public interface IAboutService
    {
        /// <summary>
        /// The GetAllAbout.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{About}"/>.</returns>
        IPagedList<About> GetAllAbout(string title = "", int pageIndex = 1, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetAboutById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="About"/>.</returns>
        About GetAboutById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="about">The about<see cref="About"/>.</param>
        void Insert(About about);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="about">The about<see cref="About"/>.</param>
        void Update(About about);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);

        /// <summary>
        /// The GetActiveAbout.
        /// </summary>
        /// <returns>The <see cref="About"/>.</returns>
        About GetActiveAbout();
    }
}
