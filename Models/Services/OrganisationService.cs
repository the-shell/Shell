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
                from o in this._repository.Get()
                where o.OwnerId == userId
                select o; 
        }

        public int CreateOrganisation(Organisation model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            return this._repository.Create(model);
        }

        public Organisation GetOrganisation(int id)
        {
            var org = this._repository.GetById(id);
            return org;
        }
    }
}