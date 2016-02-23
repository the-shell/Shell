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
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public OrganisationRepository(IDbConnectionFactory factory)
        {
            _dbConnectionFactory = factory;
        }

        public int Insert(Organisation entity)
        {
            var adminUser = entity.Users.FirstOrDefault();
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                using (var trans = conn.BeginTransaction())
                {
                    {
                        entity.Id = (int)conn.Query<decimal>(@"
insert into Organisations(Name) 
    values (@name) 
    select CAST(SCOPE_IDENTITY() as int)", new { entity.Name }, transaction: trans).Single();

                        conn.Query(@"
insert into OrganisationUser(OrganisationId, UserId, Role) 
    values (@OrganisationId, @UserId, @Role)", new {
                            OrganisationId = entity.Id,
                            UserId = adminUser.Id,
                            Role = Role.Admin
                        }, transaction: trans);

                        trans.Commit();
                        return entity.Id;
                    }
                }
            }
        }

        public void Delete(Organisation entity)
        {
            throw new NotImplementedException();
        }

        public List<Organisation> GetUserOrganisations(string userId)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var orgs = conn.Query<Organisation>(@"
SELECT * FROM Organisations
    INNER JOIN OrganisationUser ON Organisations.Id = OrganisationUser.OrganisationId
    WHERE OrganisationUser.UserId = @UserId", new { UserId = userId }).ToList();

                return orgs;
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

        public Organisation GetById(int id)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var org = conn.Query<Organisation>(@"
SELECT * FROM Organisations
    WHERE Organisations.Id = @id",
    new { id }).FirstOrDefault();
                return org;
            }
        }
    }
}

//SELECT Orgs.Id as OrganisationId, Orgs.Name as OrganisationName, OrgUser.Role as UserRole
//    FROM OrganisationUser OrgUser
//    INNER JOIN Organisations Orgs ON Orgs.Id = OrgUser.OrganisationId
//    WHERE OrgUser.UserId = @UserId", new { UserId = userId }).ToList();