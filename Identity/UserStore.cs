using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Shell.Models;
using Dapper;

namespace Shell.Identity
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>
    {
        private string connectionString { get; set; }

        public UserStore()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        #region IUserStore

        public Task CreateAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                user.Id = Guid.NewGuid();
                using (SqlConnection connection = new SqlConnection(connectionString))
                    connection.Execute("insert into Users(Id, UserName, PasswordHash, SecurityStamp, EmailAddress, FirstName, LastName) values(@Id, @userName, @passwordHash, @securityStamp, @emailAddress, @firstName, @lastName)", user);
            });
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            Guid parsedUserId;
            if (!Guid.TryParse(userId, out parsedUserId))
                throw new ArgumentOutOfRangeException("userId", string.Format("'{0}' is not a valid GUID.", new { userId }));

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                    return con.Query<User>("select * from Users where Id = @Id", new { Id = parsedUserId }).SingleOrDefault();
            });
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var results = connection.Query<User>("select * from Users where UserName = @UserName", new { UserName = userName });//.SingleOrDefault();
                    foreach(var a in results)
                    {
                        Console.WriteLine(a);
                    }
                    return results.FirstOrDefault();
                }
            });
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        #endregion IUserStore

        #region IUserPasswordStore

        public virtual Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PasswordHash);
        }

        public virtual Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public virtual Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        #endregion IUserPasswordStore

        #region IUserSecurityStampStore

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        #endregion IUserSecurityStampStore
    }
}