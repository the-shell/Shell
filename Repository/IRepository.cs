using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Shell.Repository
{
    public interface IRepository<TEntity>
    {
        void Delete(TEntity entity);
    }
}