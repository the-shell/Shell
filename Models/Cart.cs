using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual Product Product { get; set; }
    }
}