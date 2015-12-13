using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.Models;
using Shell.Models.Repository;
using Shell.UI.ViewModels.Organisation;

namespace Shell.DAL
{
    public class SqlOrganisationRepository : OrganisationRepository
    {
        private readonly ApplicationDbContext _context;

        public SqlOrganisationRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException();
            this._context = context;
        }

        public Organisation GetById(int id)
        {
            return 
                _context.Organisations.Where(o => o.Id == id).First();

        }

        public IQueryable<Organisation> Get()
        {
            return
                from o in this._context.Organisations
                select o;
        }

        int IRepository<Organisation, int>.Create(Organisation entity)
        {
            var o = _context.Organisations.Add(entity);
            _context.SaveChanges();
            return o.Id;
        }

        public void Update(Organisation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Organisation entity)
        {
            throw new NotImplementedException();
        }
    }
}