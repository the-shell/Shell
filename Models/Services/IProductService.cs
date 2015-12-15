using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Models.Services
{
    public interface IProductService
    {
        int CreateProduct(Product product);

        Product GetProduct(int id);

        List<Product> GetProducts(int orgId);
    }
}