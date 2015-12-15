using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.UI.ViewModels.Organisation;

namespace Shell.Models.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);

        IQueryable<TEntity> Get();

        int Create(TEntity entity);
    }
}