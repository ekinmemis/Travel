using System.Web.Mvc;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
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