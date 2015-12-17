using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shell.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public virtual Organisation Organisation { get; set; }

        //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime DateListed { get; set; }

        //public Category Category { get; set; }

        //public DateTime DateListed { get; set; }

        //public virtual ICollection<ProductImage> Images { get; set; }

        public int This { get; set; }
    }
}