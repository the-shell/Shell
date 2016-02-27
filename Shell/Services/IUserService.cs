using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Services
{
    /// <summary>
    /// The service for all User related activities (other than Authentication)
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all the businesses associated with the user Id provided
        /// </summary>
        /// <param name="userId">The User Id to find businesses for</param>
        /// <returns>A list of Business objects associated with the user</returns>
        List<Business> GetBusinesses(Guid userId);
    }
}
