using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using Shell.Models.Repository;
using Shell.UI.ViewModels.Organisation;
using System.Web.Mvc;
using Shell.UI.ViewModels.Manage;

namespace Shell.Models.Services
{
    
    public class OrganisationService
    {
        private readonly OrganisationRepository _repository;

        public OrganisationService(OrganisationRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repo");
            }
            this._repository = repository;
        }

        public IEnumerable<Organisation> GetOrganisations(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("user");
            }
            return
                from o in this._repository.GetOrganisations()
                where o.OwnerId == userId
                select o; 
        }

        public int CreateOrganisation(CreateOrganisationViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            return this._repository.CreateOrganisation(new Organisation
            {
                Name = model.Name,
                OwnerId = UserId
            });
        }

        public DetailsViewModel GetOrganisation(int id)
        {
            var org = this._repository.GetOrganisationById(id);
            return new DetailsViewModel
            {
                Name = org.Name
            };
        }
    }
}