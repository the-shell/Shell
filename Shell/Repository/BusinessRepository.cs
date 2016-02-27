using Dapper;
using Shell.DAL;
using Shell.Models;
using Shell.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Shell.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public BusinessRepository(IDbConnectionFactory factory)
        {
            _dbConnectionFactory = factory;
        }

        public int Insert(Business entity)
        {
            //The user who is creating the business
            var adminUser = entity.Users.FirstOrDefault();
            entity.DateCreated = DateTime.UtcNow;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                using (var trans = conn.BeginTransaction())
                {
                    {
                        entity.Id = (int)conn.Query<decimal>(@"
insert into Businesses(Name, Description, Phone, Email, DateCreated) 
    values (@name, @description, @phone, @email, @DateCreated) 
    select CAST(SCOPE_IDENTITY() as int)", new {
                        entity.Name,
                        entity.Description,
                        entity.Phone,
                        entity.Email,
                        entity.DateCreated
                        }, transaction: trans).Single();

                        conn.Query(@"
insert into BusinessUsers(BusinessId, UserId, Role) 
    values (@BusinessId, @UserId, @Role)", new {
                            BusinessId = entity.Id,
                            UserId = adminUser.Id,
                            Role = Role.Admin
                        }, transaction: trans);
                        trans.Commit();

                        return entity.Id;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                using (var trans = conn.BeginTransaction())
                {
                    conn.Execute(@"
DELETE FROM Businesses
    WHERE Businesses.Id = @Id",
    new { Id = id }, trans);
                    conn.Execute(@"
DELETE FROM BusinessUsers
    WHERE BusinessUsers.BusinessId = @Id",
    new { Id = id }, trans);
                    trans.Commit();
                }
            }
        }

        public bool IsAdmin(string userId, int orgId)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var isAdmin = conn.Execute(@"
SELECT OrganisationUser.Role FROM OrganisationUser
    WHERE OrganisationUser.UserId = @userId AND OrganisationUser.OrganisationId = @orgId",
    new { userId, orgId }
    );
                if (isAdmin == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Business GetById(int id)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var org = conn.Query<Business>(@"
SELECT * FROM Businesses
    WHERE Businesses.Id = @id",
    new { id }).FirstOrDefault();

                return org;
            }
        }

        public List<User> GetUsers(int id)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var users = conn.Query<User>(@"
SELECT * FROM Users
    INNER JOIN BusinessUsers ON Users.Id = BusinessUsers.UserId
    WHERE BusinessUsers.BusinessId = @id",
    new { id });

                return users.ToList();
            }
        }

        public void AddUserToBusiness(Guid userId, int businessId, Role role)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Execute(@"
INSERT INTO BusinessUsers(BusinessId, UserId, Role)
    VALUES (@BusinessId, @UserId, @Role)",
    new
    {
        BusinessId = businessId,
        UserId = userId,
        Role = role
    });
            }
        }

        public void AddUserToBusiness(Guid userId, int businessId)
        {
            throw new NotImplementedException();
        }
    }
}