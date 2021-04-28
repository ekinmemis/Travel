using Core;
using Core.Domain.Categories;
using Data.EfRepository;
using System.Linq;

namespace Services.CategoryServices
{
    /// <summary>
    /// Defines the <see cref="CategoryService" />.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Defines the _categoryRepository.
        /// </summary>
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }



        /// <summary>
        /// The GetAllCategory.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Category}"/>.</returns>
        public IPagedList<Category> GetAllCategory(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _categoryRepository.Table.Where(f => f.Deleted != true);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            query = query.OrderBy(o => o.Id);

            var categorys = new PagedList<Category>(query, pageIndex, pageSize);

            return categorys;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);

            _categoryRepository.Delete(category);
        }

        /// <summary>
        /// The GetCategoryById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Category"/>.</returns>
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        public void Insert(Category category)
        {
            _categoryRepository.Insert(category);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
