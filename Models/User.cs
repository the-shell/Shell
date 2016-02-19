using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shell.Models
{
    public class User : IUser<string>
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        string IUser<string>.Id
        {
            get
            {
                return Id.ToString();
            }
        }

        public ICollection<Store> Stores { get; set; }

        public string UserName
        {
            get
            {
                return EmailAddress;
            }

            set
            {
                string.Concat(EmailAddress);
            }
        }
    }
}