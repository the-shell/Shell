using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.ViewModels
{
    public class ManageViewModel
    {
        public List<OrganisationListViewModel> Organisations { get; set; }
    }

    public class OrganisationListViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}