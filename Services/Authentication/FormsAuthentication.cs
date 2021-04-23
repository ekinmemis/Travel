using Core.Domain.ApplicationUsers;
using Data.EfRepository;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Service.Authentication
{
    /// <summary>
    /// Defines the <see cref="FormsAuthenticationService" />.
    /// </summary>
    public class FormsAuthenticationService : IAuthenticationService
    {
        #region Fields

        /// <summary>
        /// Defines the _applicationUserRepository.
        /// </summary>
        private readonly IRepository<ApplicationUser> _applicationUserRepository;

        /// <summary>
        /// Defines the _httpContext.
        /// </summary>
        private readonly HttpContext _httpContext;

        /// <summary>
        /// Defines the _appUser.
        /// </summary>
        private ApplicationUser _appUser;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FormsAuthenticationService"/> class.
        /// </summary>
        public FormsAuthenticationService()
        {
            _applicationUserRepository = new Repository<ApplicationUser>();
            _httpContext = HttpContext.Current;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The GetAuthenticatedApplicationUserFromTicket.
        /// </summary>
        /// <param name="ticket">The ticket<see cref="FormsAuthenticationTicket"/>.</param>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        protected virtual ApplicationUser GetAuthenticatedApplicationUserFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var email = ticket.UserData;

            if (String.IsNullOrWhiteSpace(email))
                return null;

            var applicationUser = _applicationUserRepository.Table.FirstOrDefault(f => f.Email == email);

            if (applicationUser == null)
                return null;

            return applicationUser;
        }

        /// <summary>
        /// The SignIn.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        /// <param name="rememberMe">The rememberMe<see cref="bool"/>.</param>
        public virtual void SignIn(ApplicationUser applicationUser, bool rememberMe)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1 /*version*/, applicationUser.Email, now, now.AddMinutes(15), rememberMe, applicationUser.Email, FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;

            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;

            if (FormsAuthentication.CookieDomain != null)
                cookie.Domain = FormsAuthentication.CookieDomain;

            _httpContext.Response.Cookies.Add(cookie);
            _appUser = applicationUser;
        }

        /// <summary>
        /// The SignOut.
        /// </summary>
        public virtual void SignOut()
        {
            _appUser = null;
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// The GetAuthenticatedApplicationUser.
        /// </summary>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        public virtual ApplicationUser GetAuthenticatedApplicationUser()
        {
            if (_appUser != null)
                return _appUser;

            if (_httpContext == null || _httpContext.Request == null || !_httpContext.Request.IsAuthenticated || !(_httpContext.User.Identity is FormsIdentity))
                return null;

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;

            var applicationUser = GetAuthenticatedApplicationUserFromTicket(formsIdentity.Ticket);

            if (applicationUser != null)
                _appUser = applicationUser;

            return _appUser;
        }

        #endregion
    }
}
