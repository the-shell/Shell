using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class Category
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}