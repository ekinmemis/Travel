using Core.Domain.Categories;

using Services.CategoryServices;

using System.IO;
using System.Web;
using System.Web.Mvc;

using Travel.Configurations;
using Travel.Models.Category;

namespace Travel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new CategoryListModel());
        }

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

        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

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
