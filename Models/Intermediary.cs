using Dapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Shell.Models;

namespace Shell.Identity
{
    public class StoreUser
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public User UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        Standard
    }
}