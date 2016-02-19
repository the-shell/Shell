using Shell.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shell.Repository
{
    public class DapperRepository<T> : IRepository<T>
    {
        private readonly IDbConnection conn;

        public DapperRepository(IDbConnection Connection)
        {
            conn = Connection;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}