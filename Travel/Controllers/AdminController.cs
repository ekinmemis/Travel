﻿using Service.Authentication;

using Services.ApplicationUserServices;

using System.Web.Mvc;

using Travel.Models.Admin;

namespace Travel.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _formsAuthenticationService;

        private readonly IApplicationUserService _applicationUserService;

        public AdminController(IAuthenticationService formsAuthenticationService, IApplicationUserService applicationUserService)
        {
            _formsAuthenticationService = formsAuthenticationService;
            _applicationUserService = applicationUserService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

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

        public ActionResult Content()
        {
            return View();
        }

        public ActionResult Logout()
        {
            _formsAuthenticationService.SignOut();

            return Redirect("/");
        }
    }
}
