using Shell.Models;
using Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Services
{
    public interface IOrganisationService
    {
        List<OrganisationListViewModel> GetUserOrganisations(string userId);
        void Create(CreateOrganisationViewModel org);
    }
}
