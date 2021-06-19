namespace Travel.Controllers
{
    using Core.Domain.Main;

    using Humanizer;

    using Services.AboutServices;
    using Services.BlogServices;
    using Services.ContactServices;

    using System.Web.Mvc;

    using Travel.Configurations;
    using Travel.Factories;
    using Travel.Models.About;
    using Travel.Models.Blog;
    using Travel.Models.Contact;

    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;
        private readonly IBlogService _blogService;
        private readonly IBlogModelFactory _blogModelFactory;

        public HomeController(IAboutService aboutService, IContactService contactService, IBlogModelFactory blogModelFactory, IBlogService blogService)
        {
            _aboutService = aboutService;
            _contactService = contactService;
            _blogModelFactory = blogModelFactory;
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(BlogPagingFilteringModel command)
        {
            var model = _blogModelFactory.PrepareBlogListModel(command);
            return View(model);
        }

        public ActionResult Single(int id)
        {
            var blog = _blogService.GetBlogById(id);
            var model = blog.MapTo<Blog, BlogModel>();
            return View(model);
        }

        public ActionResult About()
        {
            var about = _aboutService.GetActiveAbout();
            AboutModel model = about.MapTo<About, AboutModel>();
            model.DateString = model.CreateDate.Humanize();
            return View(model);
        }

        public ActionResult Contact()
        {
            var contact = _contactService.GetActiveContact();
            ContactModel model = contact.MapTo<Contact, ContactModel>();
            return View(model);
        }
    }
}
