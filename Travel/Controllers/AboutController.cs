using Core.Domain.Main;
using Services.AboutServices;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Travel.Models.About;

namespace Travel.Controllers
{
    public class AboutController : Controller
    {
        // GET: Abour
        private readonly IAboutService _aboutService;

        public AboutController()
        {
            _aboutService = new AboutService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AboutListModel());
        }

        [HttpPost]
        public ActionResult List(AboutListModel model)
        {
            var abouts = _aboutService.GetAllAbout(
                title: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = abouts.TotalCount,
                data = abouts
            });
        }

        public ActionResult Create()
        {
            return View(new AboutModel());
        }

        [HttpPost]
        public ActionResult Create(AboutModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string imagee = Path.GetFileName(image.FileName);
                    string path = "~/Content/travel/images/" + imagee;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                }

                var about = new About
                {
                    Id = model.Id,
                    CreateDate = model.CreateDate,
                    Definition = model.Definition,
                    ShortDefinition = model.ShortDefinition,
                    Image = image.FileName,
                    IsActive = model.IsActive,
                    Note = model.Note,
                    Title = model.Title
                };

                _aboutService.Insert(about);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var about = _aboutService.GetAboutById(id);

            if (about == null || about.Deleted)
                return RedirectToAction("List");

            var model = new AboutModel()
            {
                Id = about.Id,
                CreateDate = about.CreateDate,
                Definition = about.Definition,
                ShortDefinition = about.ShortDefinition,
                Image = about.Image,
                IsActive = about.IsActive,
                Note = about.Note,
                Title = about.Title
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AboutModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var about = _aboutService.GetAboutById(model.Id);

                if (about == null || about.Deleted)
                    return RedirectToAction("List");
                if (image != null)
                {
                    string imagee = Path.GetFileName(image.FileName);
                    string path = "~/Content/travel/images/" + imagee;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    about.Image = image.FileName;
                }

                about.Id = model.Id;
                about.CreateDate = model.CreateDate;
                about.Definition = model.Definition;
                about.ShortDefinition = model.ShortDefinition;
                about.IsActive = model.IsActive;
                about.Note = model.Note;
                about.Title = model.Title;

                _aboutService.Update(about);
            }

            return RedirectToAction("List");
        }

        
        public ActionResult Delete(int id)
        {
            var about = _aboutService.GetAboutById(id);

            if (about == null)
                return Json("ERR");

            about.Deleted = true;

            _aboutService.Update(about);

            return Json("OK",JsonRequestBehavior.AllowGet);
        }
    }
}