using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.UI.ViewModels.Organisation;
using System.Linq.Expressions;

namespace Shell.Models.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void Insert(TEntity entity);

        void Delete(TEntity entity);
    }
}