using Shell.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("product repo");
            }
            this._repository = repository;
        }

        public int CreateProduct(Product product)
        {
            return this._repository.Create(product);
        }

        public Product GetProduct(int id)
        {
            return
                this._repository.GetById(id);
        }


        public List<Product> GetProducts(int id)
        {
            return
                this._repository.Get()
                .Where(p => p.Organisation.Id == id).ToList();
        }
    }
}