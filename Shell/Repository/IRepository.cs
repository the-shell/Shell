using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Shell.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        int Insert(TEntity entity);
        void Delete(int id);
    }
}