using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models.Services
{
    public interface IOrganisationService
    {
        int CreateOrganisation(Organisation model);

        Organisation GetOrganisation(int id);

        List<Organisation> GetOrganisations(string userId);   
              
    }
}