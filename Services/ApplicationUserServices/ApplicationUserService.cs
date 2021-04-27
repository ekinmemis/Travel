using Core;
using Core.Domain.ApplicationUsers;
using Data.EfRepository;
using System;
using System.Linq;

namespace Services.ApplicationUserServices
{
    /// <summary>
    /// Defines the <see cref="ApplicationUserService" />.
    /// </summary>
    public class ApplicationUserService : IApplicationUserService
    {
        /// <summary>
        /// Defines the _applicationUserRepository.
        /// </summary>
        private IRepository<ApplicationUser> _applicationUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserService"/> class.
        /// </summary>
        public ApplicationUserService()
        {
            _applicationUserRepository = new Repository<ApplicationUser>();
        }

        /// <summary>
        /// The GetAllApplicationUsers.
        /// </summary>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{ApplicationUser}"/>.</returns>
        public IPagedList<ApplicationUser> GetAllApplicationUsers(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _applicationUserRepository.Table.Where(f => f.Deleted != true);

            query = query.Skip(pageSize * pageIndex).Take(pageSize);

            query = query.OrderBy(o => o.Id);

            var applicaionUsers = new PagedList<ApplicationUser>(query, pageIndex, pageSize);

            return applicaionUsers;
        }

        /// <summary>
        /// The GetApplicationUserById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        public ApplicationUser GetApplicationUserById(int id)
        {
            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var applicationUser = _applicationUserRepository.GetById(id);

            return applicationUser;
        }

        /// <summary>
        /// The GetApplicationUserByEmail.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <returns>The <see cref="ApplicationUser"/>.</returns>
        public ApplicationUser GetApplicationUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw (new ArgumentNullException("parameter missing"));

            var applicationUser = _applicationUserRepository.Table.FirstOrDefault(f => f.Email == email);

            return applicationUser;
        }

        /// <summary>
        /// The InsertApplicationUser.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        public void InsertApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw (new ArgumentNullException("parameter missing"));

            _applicationUserRepository.Insert(applicationUser);
        }

        /// <summary>
        /// The UpdateApplicationUser.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        public void UpdateApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw (new ArgumentNullException("parameter missing"));

            _applicationUserRepository.Update(applicationUser);
        }

        /// <summary>
        /// The DeleteApplicationUser.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="ApplicationUser"/>.</param>
        public void DeleteApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw (new ArgumentNullException("parameter missing"));

            _applicationUserRepository.Delete(applicationUser);
        }
    }
}
