using Humanizer;
using Services.AboutServices;
using Services.ContactServices;
using Services.SliderServices;
using System.Web.Mvc;
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

        /// <summary>
        /// The Contact.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Contact()
        {
            var contact = _contactService.GetActiveContact();

            return View(new ContactModel()
            {
                Id = contact.Id,
                Title = contact.Title,
                Definition = contact.Definition,
                EmailAddress = contact.EmailAddress,
                EmailSubject = contact.EmailSubject,
                IsActive = contact.IsActive,
                PhoneNumberSubject = contact.PhoneNumberSubject,
                PhoneNumberTitle = contact.PhoneNumberTitle,
                PostalAddressSubject = contact.PostalAddressSubject,
                PostalAdressTitle = contact.PostalAdressTitle
            });
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