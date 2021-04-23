using Core;
using Core.Domain.Categories;

namespace Services.CategoryServices
{
    /// <summary>
    /// Defines the <see cref="ICategoryService" />.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// The GetAllCategory.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Category}"/>.</returns>
        IPagedList<Category> GetAllCategory(string title = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetCategoryById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Category"/>.</returns>
        Category GetCategoryById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        void Insert(Category category);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        void Update(Category category);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);
    }
}
