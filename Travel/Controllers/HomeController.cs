using Humanizer;
using Services.AboutServices;
using System.Web.Mvc;
using Travel.Models.About;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;

        public HomeController()
        {
            _aboutService = new AboutService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var about = _aboutService.GetActiveAbout();

            return View(new AboutModel()
            {
                CreateDate = about.CreateDate,
                DateString = about.CreateDate.Humanize(),
                Definition = about.Definition,
                Image = about.Image,
                IsActive = about.IsActive,
                ShortDefinition = about.ShortDefinition,
                Title = about.Title,
                Note = about.Note
            });
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult RightSideBar()
        {
            return PartialView();
        }
    }
}