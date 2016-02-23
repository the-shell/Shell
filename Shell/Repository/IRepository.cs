using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Shell.Repository
{
    public interface IRepository<TEntity>
    {
        int Insert(TEntity entity);
        void Delete(TEntity entity);
    }
}