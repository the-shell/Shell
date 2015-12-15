using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Shell.Models;
using Shell.ViewModels.Product;
using Microsoft.AspNet.Identity.Owin;

namespace Shell.DAL
{
    public class StoreRepository
    {
        //private ApplicationDbContext context = new ApplicationDbContext();
        //ApplicationUser user =
        //        System.Web.HttpContext.Current.GetOwinContext()
        //            .GetUserManager<ApplicationUserManager>()
        //            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        //public bool AddNewProduct(Product model)
        //{
        //   try
        //    {
        //        context.Products.Add(model);
        //        context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //public IEnumerable<Product> AllProducts()
        //{
        //    //ICollection<Product> products = new Collection<Product>();
        //    List<Product> products = context.Products.Where(p => p.Id != 0).ToList();

        //    return products;
        //}

        //public IEnumerable<Product> AllProducts(string searchString)
        //{
        //    //ICollection<Product> products = new Collection<Product>();
        //    List<Product> products = context.Products.Where(p => p.Title.Contains(searchString)).ToList();

        //    return products;
        //}

        //public IEnumerable<Category> CategoriesWithMostProducts()
        //{
        //    IEnumerable<Category> categories = context.Categories.Where(p => p.Name != null).Take(12);

        //    return categories;
        //}

        //public IEnumerable<Product> LatestListings()
        //{
        //    IEnumerable<Product> latestListings = context.Products.OrderByDescending(p => p.DateListed).Take(15);

        //    return latestListings;
        //}

        //public int CreateOrganisation(CreateViewModel model)
        //{
        //    Organisation o = new Organisation
        //    {
        //        Name = model.Name
        //    };

        //    context.Organisations.Add(o);
        //    context.SaveChanges();
        //    string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        //    o.Users = new List<ApplicationUser>()
        //    {
        //        user
        //    };
        //    context.SaveChanges();
        //    return o.Id;
        //}

        //public Organisation GetOrganisation(int orgId)
        //{
        //    return context.Organisations.Where(p => p.Id == orgId).First();
        //}

        //public IEnumerable<Organisation> GetUserOrganisations()
        //{
        //    var orgs = user.Organisations.Where(p => p.Name != null);
        //    return orgs;
        //}
    }
}