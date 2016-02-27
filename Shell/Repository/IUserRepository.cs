using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Repository
{
    public interface IUserRepository
    {
        ///<summary>
        ///This is iterator
        ///</summary>
        List<Business> GetBusinesses(Guid userId);
    }
}
