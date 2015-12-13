using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models.Repository
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity GetById(TKey id);
        IQueryable<TEntity> Get();
        int Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}