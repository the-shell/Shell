using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell.Models;
using Shell.DAL;
using Dapper;

namespace Shell.Repository
{
    public class UserRepository : IUserRepository
    {
        private IDbConnectionFactory _factory;

        public UserRepository(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        //<summary>
        //Return a list
        //</summary>
        public List<Business> GetBusinesses(Guid userId)
        {
            using (var conn = _factory.CreateConnection())
            {
                var orgs = conn.Query<Business>(@"
SELECT * FROM Businesses
    INNER JOIN BusinessUsers ON Businesses.Id = BusinessUsers.BusinessId
    WHERE BusinessUsers.UserId = @UserId", new { UserId = userId }).ToList();
                return orgs;
            }
        }       
    }
}
