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

        public override IEnumerable<Organisation> GetOrganisations()
        {
            return
                from o in this._context.Organisations
                select o;
        }

        public override int CreateOrganisation(Organisation model)
        {
            var o = _context.Organisations.Add(model);
            _context.SaveChanges();
            return o.Id;
        }

        //Todo refactor this and change GetOrganisations in OrganisationService to filter by id
        public override Organisation GetOrganisationById(int id)
        {
           return _context.Organisations.Where(o => o.Id == id).First();
        }
    }
}