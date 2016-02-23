using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class Organisation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public DateTime DateCreated { get; set; }

        public List<User> Users { get; set; }
    }

    public class OrganisationRole
    {
        public Organisation Organisation { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}