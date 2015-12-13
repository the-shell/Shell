using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.UI.ViewModels.Manage;
using Microsoft.AspNet.Identity;

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
    }
}