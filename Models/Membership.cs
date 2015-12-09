using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public Organisation Organisation { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
    }
}