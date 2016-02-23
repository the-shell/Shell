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

        public int Create(Organisation model)
        {
            model.DateCreated = DateTime.UtcNow;
            return _repository.Insert(model);
        }

        public Organisation GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<OrganisationListViewModel> GetUserOrganisationList(string userId)
        {
            var userOrgs = _repository.GetUserOrganisations(userId);
            List<OrganisationListViewModel> orgs = new List<OrganisationListViewModel>();

            orgs = userOrgs.Select(org => new OrganisationListViewModel
            {
                Id = org.Id,
                Name = org.Name,
                RoleName = _repository.IsAdmin(userId, org.Id) ? "Admin" : "Standard User"
            }).ToList();
            return orgs;
        }
    }
}