using Shell.Models;
using Shell.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.DAL
{
    public class SqlProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;

        public SqlProductRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException();
            this._context = context;
        }

        public int Create(Product entity)
        {
            this._context.Products.Add(entity);
            this._context.SaveChanges();
            return entity.Id;
        }

        public IQueryable<Product> Get()
        {
            return this._context.Products;
        }

        public Product GetById(int id)
        {
            return this._context.Products.Where(p => p.Id == id).First();
        }
    }
}