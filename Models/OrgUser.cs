using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class OrganisationPermissons
    {
        public int id { get; set; }
        public Organisation Organisation { get; set; }
        public string UserId { get; set; }
        public string Permission { get; set; }
    }
}