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

        public List<OrganisationListViewModel> GetUserOrganisations(string userId)
        {
            var userOrgs = _repository.GetUserOrganisations(userId);
            List<OrganisationListViewModel> orgs = new List<OrganisationListViewModel>();
            foreach (var org in userOrgs)
            {
                orgs.Add(new OrganisationListViewModel
                {
                    Name = org.Name,
                    Id = org.Id,
                    RoleName = _repository.IsAdmin(userId, org.Id) ? "Admin" : "Standard User"
                });
            }
            return orgs;
        }
    }
}