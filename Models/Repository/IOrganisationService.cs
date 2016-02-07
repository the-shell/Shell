using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Models.Repository
{
    public interface IOrganisationService
    {
        IEnumerable<Organisation> GetLatestOrganisations();

        int Create(Organisation org);
    }
}
