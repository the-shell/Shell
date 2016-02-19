using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.Models;

namespace Shell.ViewModels
{
    public class StoreFrontViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Models.Product> LatestListings { get; set; }
    }
}