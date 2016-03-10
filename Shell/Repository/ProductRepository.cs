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

        public ProductRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Delete(int id)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Execute(@"
DELETE FROM Products 
    WHERE Products.Id = @Id",
    new { Id = id });
            }
        }

        public Product GetById(int id)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var product = conn.Query<Product>(@"
SELECT * FROM Products 
    WHERE Products.Id = @Id",
    new { Id = id }).SingleOrDefault();
                return product;
            }
        }

        public int Insert(Product entity)
        {
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                entity.Id = (int)conn.Query<decimal>(@"
INSERT INTO Products(BusinessId, UserId, Name, Description, Price, DateCreated, DisplayImage)
    VALUES(@BusinessId, @UserId, @Name, @Description, @Price, @DateCreated, @DisplayImage)
    SELECT CAST(SCOPE_IDENTITY() AS int)",
    new
    {
        BusinessId = entity.BusinessId,
        UserId = entity.UserId,
        Name = entity.Name,
        Description = entity.Description,
        Price = entity.Price,
        DateCreated = DateTime.UtcNow,
        DisplayImage = entity.DisplayImage
    }).Single();
                return entity.Id;

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