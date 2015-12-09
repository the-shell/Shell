using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.UI.ViewModels.Organisation;

namespace Shell.Models.Repository
{
    public abstract class OrganisationRepository
    {
        public abstract IEnumerable<Organisation> GetOrganisations();

        public abstract Organisation GetOrganisationById(int id);

        public abstract int CreateOrganisation(Organisation model);

    }
}