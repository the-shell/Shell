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

        public IQueryable<Product> Products { get; set; }

        public DateTime DateCreated { get; set; }
    }
}