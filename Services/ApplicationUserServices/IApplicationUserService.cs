using Core;
using Core.Domain.ApplicationUsers;

namespace Services.ApplicationUserServices
{
    /// <summary>
    /// Defines the <see cref="IApplicationUserService" />.
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// The GetAllApplicationUsers.
        /// </summary>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{ApplicationUser}"/>.</returns>
        IPagedList<ApplicationUser> GetAllApplicationUsers(int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetApplicationUserById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        ApplicationUser GetApplicationUserById(int id);

        /// <summary>
        /// The GetApplicationUserByEmail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        ApplicationUser GetApplicationUserByEmail(string email);

        /// <summary>
        /// The InsertApplicationUser.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        void InsertApplicationUser(ApplicationUser applicationUser);

        /// <summary>
        /// The UpdateApplicationUser.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        void UpdateApplicationUser(ApplicationUser applicationUser);

        /// <summary>
        /// The DeleteApplicationUser.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        void DeleteApplicationUser(ApplicationUser applicationUser);
    }
}
