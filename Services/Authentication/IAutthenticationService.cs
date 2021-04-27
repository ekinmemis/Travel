using Core.Domain.ApplicationUsers;

namespace Service.Authentication
{
    /// <summary>
    /// Defines the <see cref="IAuthenticationService" />.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// The SignIn.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        /// <param name="rememberMe">The rememberMe<see cref="bool"/>.</param>
        void SignIn(ApplicationUser applicationUser, bool rememberMe);

        /// <summary>
        /// The SignOut.
        /// </summary>
        void SignOut();

        /// <summary>
        /// The GetAuthenticatedApplicationUser.
        /// </summary>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        ApplicationUser GetAuthenticatedApplicationUser();
    }
}
