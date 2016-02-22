using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Shell.Models;

namespace Shell.Identity
{
    public class CustomValidator<TUser> : IIdentityValidator<TUser> where TUser : User
    {
        private readonly UserManager<TUser> _manager;

        public CustomValidator(UserManager<TUser> manager)
        {
            _manager = manager;
        }

        public async Task<IdentityResult> ValidateAsync(TUser item)
        {
            var errors = new List<string>();

            if (_manager != null)
            {
                var account = await _manager.FindByNameAsync(item.UserName);
                if (account != null && account.Id != item.Id)
                {
                    errors.Add("An account already exists with this email address");
                }
            }
           
            return errors.Any() ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
    }
}