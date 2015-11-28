using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Shell.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Cart> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new Collection<Cart>();
                }
                return _orders;
            }
            set { _orders = value; }
        }
        private ICollection<Cart> _orders;

        public Category Category { get; set; }

        public DateTime DateListed { get; set; }
    }
}