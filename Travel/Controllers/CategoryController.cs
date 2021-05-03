using Core.Domain.Categories;
using Core.Domain.Main;
using Services.CategoryServices;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Travel.Configurations;
using Travel.Models.Category;

namespace Travel.Controllers
{
    /// <summary>
    /// Defines the <see cref="CategoryController" />.
    /// </summary>
    public class CategoryController : Controller
    {
        /// <summary>
        /// Defines the _categoryService.
        /// </summary>
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// The List.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult List()
        {
            return View(new CategoryListModel());
        }

        /// <summary>
        /// The List.
        /// </summary>
        /// <param name="model">The model<see cref="CategoryListModel"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult List(CategoryListModel model)
        {
            var categorys = _categoryService.GetAllCategory(
                title: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = categorys.TotalCount,
                data = categorys
            });
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="model">The model<see cref="CategoryModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Create(CategoryModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Category category = model.MapTo<CategoryModel, Category>();

                if (image != null)
                {
                    string imagee = Path.GetFileName(image.FileName);
                    string path = "~/Content/travel/images/" + imagee;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                }


                _categoryService.Insert(category);
            }

            return RedirectToAction("List");
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null || category.Deleted)
                return RedirectToAction("List");

            var model = new CategoryModel()
            {
                Id = category.Id,
                IsActive = category.IsActive,
                Title = category.Title
            };

            return View(model);
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="model">The model<see cref="CategoryModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryService.GetCategoryById(model.Id);

                if (category == null || category.Deleted)
                    return RedirectToAction("List");

                category.Id = model.Id;
                category.IsActive = model.IsActive;
                category.Title = model.Title;

                _categoryService.Update(category);
            }

            return RedirectToAction("List");
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
                return Json("ERR");

            category.Deleted = true;

            _categoryService.Update(category);

            return RedirectToAction("List");
        }
    }
}