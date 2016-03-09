using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.ViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BusinessId { get; set; }

        public List<Tuple<HttpPostedFileBase, bool>> Images { get; set; }
    }
}