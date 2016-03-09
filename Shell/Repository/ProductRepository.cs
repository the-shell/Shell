using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.Models;
using Shell.DAL;
using Dapper;

namespace Shell.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product entity)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var id = (int)conn.Query(@"
INSERT INTO Products(Name, Description, Price, DateCreated)
    VALUES(@Name, @Description, @Price)
    SELECT CAST(SCOPE_IDENTITY() AS int)",
    new
    {
        Name = entity.Name,
        Description = entity.Description,
        Price = entity.Price,
        DateCreated = entity.DateCreated
    }).Single();
                return id;

            }
        }

        public void Update(Product entity)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Execute(@"
UPDATE Products 
    SET (
        Name = @name,
        Description = @description,
        Price = @price,
        DisplayImage = @displayImage)
    WHERE (Id = @id)",
    new
    {
        name = entity.Name,
        description = entity.Description,
        price = entity.Price,
        displayImage = entity.DisplayImage
    });
            }
        }
    }
}