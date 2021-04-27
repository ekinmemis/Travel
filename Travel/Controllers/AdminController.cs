using Service.Authentication;
using Services.ApplicationUserServices;
using System.Web.Mvc;
using Travel.Models.Admin;

namespace Travel.Controllers
{
    /// <summary>
    /// Defines the <see cref="AdminController" />.
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        /// <summary>
        /// Defines the _formsAuthenticationService.
        /// </summary>
        private readonly IAuthenticationService _formsAuthenticationService;

        /// <summary>
        /// Defines the _applicationUserService.
        /// </summary>
        private readonly IApplicationUserService _applicationUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        public AdminController()
        {
            _formsAuthenticationService = new FormsAuthenticationService();
            _applicationUserService = new ApplicationUserService();
        }

        // GET: Admin
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        /// <summary>
        /// The Login.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="model">The model<see cref="LoginModel"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _applicationUserService.GetApplicationUserByEmail(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                    return View();
                }

                if (user.Password != model.Password)
                {
                    ModelState.AddModelError("", "Şifrenizi kontrol ediniz.");
                    return View();
                }

                _formsAuthenticationService.SignIn(user, true);

                return RedirectToAction("Content");
            }

            return View();
        }

        /// <summary>
        /// The Content.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Content()
        {
            return View();
        }

        /// <summary>
        /// The Logout.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Logout()
        {
            _formsAuthenticationService.SignOut();

            return Redirect("/");
        }
    }
}
