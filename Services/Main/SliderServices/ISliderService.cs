using Core;
using Core.Domain.Main;
using System.Collections.Generic;

namespace Services.SliderServices
{
    /// <summary>
    /// Defines the <see cref="ISliderService" />.
    /// </summary>
    public interface ISliderService
    {
        /// <summary>
        /// The GetAllSlider.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Slider}"/>.</returns>
        IPagedList<Slider> GetAllSlider(string title = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetSliderById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Slider"/>.</returns>
        Slider GetSliderById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="slider">The slider<see cref="Slider"/>.</param>
        void Insert(Slider slider);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="slider">The slider<see cref="Slider"/>.</param>
        void Update(Slider slider);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="List{Slider}"/>.</returns>
        List<Slider> GetAll();
    }
}
