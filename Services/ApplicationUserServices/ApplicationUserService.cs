using Core;
using Core.Domain.ApplicationUsers;
using Data.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ApplicationUserServices
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IRepository<ApplicationUser> _applicationUserRepository;

        public ApplicationUserService()
        {
            _applicationUserRepository = new Repository<ApplicationUser>();
        }

        public IPagedList<ApplicationUser> GetAllApplicationUsers(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _applicationUserRepository.Table;

            query = query.Skip(pageSize * pageIndex).Take(pageSize);

            query = query.OrderBy(o => o.Id);

            var applicaionUsers = new PagedList<ApplicationUser>(query, pageIndex, pageSize);

            return applicaionUsers;
        }

        public ApplicationUser GetApplicationUserById(int id)
        {
            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var applicationUser = _applicationUserRepository.GetById(id);

            return applicationUser;
        }

        public ApplicationUser GetApplicationUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw (new ArgumentNullException("parameter missing"));

            var applicationUser = _applicationUserRepository.Table.FirstOrDefault(f => f.Email == email);

            return applicationUser;
        }

        public void InsertApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw (new ArgumentNullException("parameter missing"));

            _applicationUserRepository.Insert(applicationUser);
        }

        public void UpdateApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw (new ArgumentNullException("parameter missing"));

            _applicationUserRepository.Update(applicationUser);
        }

        public void DeleteApplicationUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw (new ArgumentNullException("parameter missing"));

            _applicationUserRepository.Delete(applicationUser);
        }
    }
}