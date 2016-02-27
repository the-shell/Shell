using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
    }

    public class OrganisationRole
    {
        public Business Organisation { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}