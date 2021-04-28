using Core.Domain.Main;
using Humanizer;
using Services.AboutServices;
using Services.ContactServices;
using Services.SliderServices;
using System.Web.Mvc;
using Travel.Configurations;
using Travel.Models.About;
using Travel.Models.Contact;
using Travel.Models.Index;

namespace Travel.Controllers
{
    /// <summary>
    /// Defines the <see cref="HomeController" />.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Defines the _aboutService.
        /// </summary>
        private readonly IAboutService _aboutService;

        private readonly IContactService _contactService;
        private readonly ISliderService _sliderService;

        public HomeController(IAboutService aboutService, IContactService contactService, ISliderService sliderService)
        {
            _aboutService = aboutService;
            _contactService = contactService;
            _sliderService = sliderService;
        }

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            var model = new IndexModel();
            model.Sliders = _sliderService.GetAll();
            return View(model);
        }

        /// <summary>
        /// The About.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult About()
        {
            var about = _aboutService.GetActiveAbout();
            AboutModel model = about.MapTo<About, AboutModel>();
            model.DateString = model.CreateDate.Humanize();
            return View(model);
        }

        /// <summary>
        /// The Contact.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Contact()
        {
            var contact = _contactService.GetActiveContact();
            ContactModel model = contact.MapTo<Contact, ContactModel>();
            return View(model);
        }

        /// <summary>
        /// The RightSideBar.
        /// </summary>
        /// <returns>The <see cref="PartialViewResult"/>.</returns>
        public PartialViewResult RightSideBar()
        {
            return PartialView();
        }
    }
}