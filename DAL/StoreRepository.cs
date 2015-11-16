using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Shell.Models;
using Shell.ViewModels.Product;

namespace Shell.DAL
{
    public class StoreRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public bool AddNewProduct(CreateProductViewModel model)
        {
            Product p = new Product
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price
            };

            try
            {
                context.Products.Add(p);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Product> AllProducts()
        {
            //ICollection<Product> products = new Collection<Product>();
            List<Product> products = context.Products.Where(p => p.Id != 0).ToList();

            return products;
        }

        public IEnumerable<Product> AllProducts(string searchString)
        {
            //ICollection<Product> products = new Collection<Product>();
            List<Product> products = context.Products.Where(p => p.Title.Contains(searchString)).ToList();

            return products;
        }
    }
}