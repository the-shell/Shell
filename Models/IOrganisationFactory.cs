using Shell.UI.ViewModels.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public interface IOrganisationFactory
    {
        Organisation Create(CreateOrganisationViewModel model);
    }
}