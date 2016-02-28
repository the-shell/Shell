using Shell.Models;
using Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Services
{
    /// <summary>
    /// The service responsible for all business related operations.
    /// </summary>
    public interface IBusinessService
    {
        /// <summary>
        /// Creates the business and associated user
        /// </summary>
        /// <param name="business">The business object to be created</param>
        /// <returns>The Id of the created business</returns>
        int Create(Business business);

        /// <summary>
        /// Get the business object with the Id given
        /// </summary>
        /// <param name="id">The Id of the business to get</param>
        /// <returns>The business object</returns>
        Business GetById(int id);

        /// <summary>
        /// Get all the users in the business with the Id given
        /// </summary>
        /// <param name="id">The Id of the business to get users for</param>
        /// <returns>A list of Users in the business</returns>
        List<User> GetUsers(int id);
    }
}
