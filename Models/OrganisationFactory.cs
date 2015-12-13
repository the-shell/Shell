using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.UI.ViewModels.Manage;
using Microsoft.AspNet.Identity;
using Shell.UI.ViewModels.Organisation;

namespace Shell.Models
{
    public class OrganisationFactory : IOrganisationFactory
    {
        private Organisation _organisation;

        public Organisation Create(CreateOrganisationViewModel model)
        {
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            _organisation = new Organisation(model.Name, UserId);
            
            return _organisation;
        }

        public DetailsViewModel GetViewModel(Organisation organisation)
        {
            return new DetailsViewModel
            {
                Name = organisation.Name,
            };
        }
    }
}