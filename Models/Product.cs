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

        public Organisation Organisation { get; set; }

        public DateTime DateListed
        {
            get
            {
                return _dateListed;
            }
            set
            {
                this._dateListed = DateTime.Now;
            }
        }
        private DateTime _dateListed { get; set; }

        //public Category Category { get; set; }

        //public DateTime DateListed { get; set; }

        //public virtual ICollection<ProductImage> Images { get; set; }
    }
}