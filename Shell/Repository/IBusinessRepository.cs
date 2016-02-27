using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Repository
{
    public interface IBusinessRepository : IRepository<Business>
    {
        bool IsAdmin(string UserId, int orgId);
        List<User> GetUsers(int id);
        void AddUserToBusiness(Guid userId, int businessId, Role role);
    }
}
