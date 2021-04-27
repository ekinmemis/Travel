using Core.Domain.Main;
using Services.AboutServices;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Travel.Models.About;

namespace Travel.Controllers
{
    /// <summary>
    /// Defines the <see cref="AboutController" />.
    /// </summary>
    public class AboutController : Controller
    {
        /// <summary>
        /// Defines the _aboutService.
        /// </summary>
        private readonly IAboutService _aboutService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutController"/> class.
        /// </summary>
        public AboutController()
        {
            _aboutService = new AboutService();
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
            return View(new AboutListModel());
        }

        /// <summary>
        /// The List.
        /// </summary>
        /// <param name="model">The model<see cref="AboutListModel"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
        {
            return View(new AboutModel());
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="model">The model<see cref="AboutModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="model">The model<see cref="AboutModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            var about = _aboutService.GetAboutById(id);

            if (about == null)
                return Json("ERR");

            about.Deleted = true;

            _aboutService.Update(about);

            return RedirectToAction("List");
        }
    }
}
