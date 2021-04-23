using Core;
using Core.Domain.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ApplicationUserServices
{
    public interface IApplicationUserService
    {
        IPagedList<ApplicationUser> GetAllApplicationUsers(int pageIndex = 0, int pageSize = int.MaxValue);

        ApplicationUser GetApplicationUserById(int id);

        ApplicationUser GetApplicationUserByEmail(string email);

        void InsertApplicationUser(ApplicationUser applicationUser);

        void UpdateApplicationUser(ApplicationUser applicationUser);

        void DeleteApplicationUser(ApplicationUser applicationUser);
    }
}
