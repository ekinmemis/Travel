using Core.Domain.Main;

using Services.BlogServices;
using Services.CategoryServices;

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

using Travel.Configurations;
using Travel.Models.Blog;

namespace Travel.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new BlogListModel());
        }

        [HttpPost]
        public ActionResult List(BlogListModel model)
        {
            var blogs = _blogService.GetAllBlogs(
                title: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = blogs.TotalCount,
                data = blogs
            });
        }

        public ActionResult Create()
        {
            var model = new BlogModel();

            foreach (var item in _categoryService.GetAllCategory())
                model.Categories.Add(new SelectListItem() { Text = item.Title, Value = item.Id.ToString() });

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BlogModel model, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            if (ModelState.IsValid)
            {
                Blog blog = model.MapTo<BlogModel, Blog>();
                blog.CreateDate = DateTime.Now;
                blog.UpdateDate = DateTime.Now;

                if (image1 != null)
                {
                    string path = "~/Content/travel/images/blog/" + Path.GetFileName(image1.FileName);
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    blog.Image1 = Path.GetFileName(image1.FileName);
                }

                if (image2 != null)
                {
                    string path = "~/Content/travel/images/blog/" + Path.GetFileName(image2.FileName);
                    Request.Files[1].SaveAs(Server.MapPath(path));
                    blog.Image2 = Path.GetFileName(image2.FileName);
                }

                _blogService.Insert(blog);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var blog = _blogService.GetBlogById(id);

            if (blog == null || blog.Deleted)
                return RedirectToAction("List");

            var model = blog.MapTo<Blog, BlogModel>();

            foreach (var item in _categoryService.GetAllCategory())
                model.Categories.Add(new SelectListItem() { Text = item.Title, Value = item.Id.ToString() });

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BlogModel model, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            if (ModelState.IsValid)
            {
                var blog = _blogService.GetBlogById(model.Id);
                if (blog == null || blog.Deleted)
                    return RedirectToAction("List");

                //automapper key error here
                blog.Title1 = model.Title1;
                blog.Image1Definition = model.Image1Definition;
                blog.Definition1 = model.Definition1;
                blog.Definition2 = model.Definition2;
                blog.Image2Definition = model.Image2Definition;
                blog.Definition3 = model.Definition3;
                blog.Title2 = model.Title2;
                blog.Definition4 = model.Definition4;
                blog.Li1 = model.Li1;
                blog.Li2 = model.Li2;
                blog.Li3 = model.Li3;
                blog.Definition5 = model.Definition5;
                blog.Title3 = model.Title3;
                blog.Definition6 = model.Definition6;
                blog.Note1 = model.Note1;
                blog.Title4 = model.Title4;
                blog.Definition7 = model.Definition7;
                blog.Note2 = model.Note2;
                blog.Ol1 = model.Ol1;
                blog.Ol2 = model.Ol2;
                blog.Ol3 = model.Ol3;
                blog.Definition8 = model.Definition8;
                blog.CategoryId = model.CategoryId;
                blog.IsActive = model.IsActive;
                blog.UpdateDate = DateTime.Now;

                if (image1 != null)
                {
                    string path = "~/Content/travel/images/blog/" + Path.GetFileName(image1.FileName);
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    blog.Image1 = Path.GetFileName(image1.FileName);
                }

                if (image2 != null)
                {
                    string path = "~/Content/travel/images/blog/" + Path.GetFileName(image2.FileName);
                    Request.Files[1].SaveAs(Server.MapPath(path));
                    blog.Image2 = Path.GetFileName(image2.FileName);
                }

                _blogService.Update(blog);
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var blog = _blogService.GetBlogById(id);

            if (blog == null)
                return Json("ERR");

            blog.Deleted = true;

            _blogService.Update(blog);

            return RedirectToAction("List");
        }
    }
}
