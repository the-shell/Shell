using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Repository
{
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        List<Organisation> GetUserOrganisations(string userId);
        bool IsAdmin(string UserId, int orgId);
        Organisation GetById(int id);
    }
}
