using Shell.Repository;
using Shell.Services;
using Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models.Repository
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _repository;

        public OrganisationService(IOrganisationRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateOrganisationViewModel model)
        {
            var org = new Organisation
            {
                Name = model.Name
            };
            _repository.Insert(org, model.UserId);
        }

        public List<Organisation> GetUserOrganisations(string userId)
        {
            return new List<Organisation>();
        }
    }
}