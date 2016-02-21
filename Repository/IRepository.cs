using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.UI.ViewModels.Organisation;
using System.Linq.Expressions;

namespace Shell.Repository
{
    public interface IRepository<TEntity>
    {
        void Delete(TEntity entity);
    }
}