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
        void Insert(Organisation org, string UserId);
    }
}
