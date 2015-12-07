using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new Collection<ApplicationUser>();
                }
                return _users;
            }
            set { _users = value; }
        }
        private ICollection<ApplicationUser> _users;

        public virtual ICollection<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new Collection<Product>();
                }
                return _products;
            }
            set { _products = value; }
        }
        private ICollection<Product> _products;
    }
}