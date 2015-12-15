using System;
using System.Linq;
using Shell.Models;
using Shell.Models.Repository;

namespace Shell.DAL
{
    public class SqlOrganisationRepository : IRepository<Organisation>
    {
        private readonly ApplicationDbContext _context;

        public SqlOrganisationRepository(ApplicationDbContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = context;
        }

        public int Create(Organisation entity)
        {
            _context.Organisations.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public IQueryable<Organisation> Get()
        {
            return this._context.Organisations;
        }

        public Organisation GetById(int id)
        {
            return this._context.Organisations
                .Where(o => o.Id == id).First();
        }
    }
}