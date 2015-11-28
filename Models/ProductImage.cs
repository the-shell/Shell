using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public string URL { get; set; }

        public bool IsDisplayPicture { get; set; }

        public virtual Product Product { get; set; }
    }
}