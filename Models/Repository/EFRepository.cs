using Shell.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Shell.Models.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private IDbSet<TEntity> _entities;

        public EFRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        private IDbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = _context.Set<TEntity>()); }
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return Entities.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}