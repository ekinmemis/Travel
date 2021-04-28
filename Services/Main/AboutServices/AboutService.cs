using Core;
using Core.Domain.Main;
using Data.EfRepository;
using System.Linq;

namespace Services.AboutServices
{
    /// <summary>
    /// Defines the <see cref="AboutService" />.
    /// </summary>
    public class AboutService : IAboutService
    {
        /// <summary>
        /// Defines the _aboutRepository.
        /// </summary>
        private readonly IRepository<About> _aboutRepository;

        public AboutService(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        /// <summary>
        /// The GetAllAbout.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{About}"/>.</returns>
        public IPagedList<About> GetAllAbout(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _aboutRepository.Table.Where(f => f.Deleted != true);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            query = query.Where(x => x.Deleted == false).OrderBy(o => o.Id);

            var abouts = new PagedList<About>(query, pageIndex, pageSize);

            return abouts;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var about = _aboutRepository.GetById(id);

            _aboutRepository.Delete(about);
        }

        /// <summary>
        /// The GetAboutById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="About"/>.</returns>
        public About GetAboutById(int id)
        {
            return _aboutRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="about">The about<see cref="About"/>.</param>
        public void Insert(About about)
        {
            _aboutRepository.Insert(about);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="about">The about<see cref="About"/>.</param>
        public void Update(About about)
        {
            _aboutRepository.Update(about);
        }

        /// <summary>
        /// The GetActiveAbout.
        /// </summary>
        /// <returns>The <see cref="About"/>.</returns>
        public About GetActiveAbout()
        {
            return _aboutRepository.Table.ToList().LastOrDefault(f => f.IsActive == true);
        }
    }
}