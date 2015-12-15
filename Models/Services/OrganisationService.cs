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

    public class OrganisationService : IOrganisationService
    {
        private readonly IRepository<Organisation> _repository;

        public OrganisationService(IRepository<Organisation> repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repo");
            }
            this._repository = repository;
        }

        public int CreateOrganisation(Organisation model)
        {
            return this._repository.Create(model);
        }

        public Organisation GetOrganisation(int id)
        {
            return this._repository.GetById(id);
        }

        public List<Organisation> GetOrganisations(string userId)
        {
            return 
                this._repository.Get()
                .Where(o =>o.OwnerId == userId).ToList();
        }
    }
}