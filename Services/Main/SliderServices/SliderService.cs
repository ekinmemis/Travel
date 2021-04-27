using Core;
using Core.Domain.Main;
using Data.EfRepository;
using System.Collections.Generic;
using System.Linq;

namespace Services.SliderServices
{
    /// <summary>
    /// Defines the <see cref="SliderService" />.
    /// </summary>
    public class SliderService : ISliderService
    {
        /// <summary>
        /// Defines the _sliderRepository.
        /// </summary>
        private readonly IRepository<Slider> _sliderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SliderService"/> class.
        /// </summary>
        public SliderService()
        {
            _sliderRepository = new Repository<Slider>();
        }

        /// <summary>
        /// The GetAllSlider.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Slider}"/>.</returns>
        public IPagedList<Slider> GetAllSlider(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _sliderRepository.Table.Where(f => f.Deleted != true);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            query = query.OrderBy(o => o.Id);

            var sliders = new PagedList<Slider>(query, pageIndex, pageSize);

            return sliders;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var slider = _sliderRepository.GetById(id);

            _sliderRepository.Delete(slider);
        }

        /// <summary>
        /// The GetSliderById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Slider"/>.</returns>
        public Slider GetSliderById(int id)
        {
            return _sliderRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="slider">The slider<see cref="Slider"/>.</param>
        public void Insert(Slider slider)
        {
            _sliderRepository.Insert(slider);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="slider">The slider<see cref="Slider"/>.</param>
        public void Update(Slider slider)
        {
            _sliderRepository.Update(slider);
        }

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="List{Slider}"/>.</returns>
        public List<Slider> GetAll() => _sliderRepository.Table.Where(f => f.Deleted != true).ToList();
    }
}
