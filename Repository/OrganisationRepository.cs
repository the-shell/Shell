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

        public void Insert(Organisation entity, string userId)
        {
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
                            UserId = userId,
                            Role = Role.Admin
                        }, transaction: trans);

                        trans.Commit();
                    }
                }
            }
        }

        public void Delete(Organisation entity)
        {
            throw new NotImplementedException();
        }
        
    }
}