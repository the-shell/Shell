using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}