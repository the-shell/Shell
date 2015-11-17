using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shell.DAL;
using Shell.Models;
using Shell.ViewModels.Product;

namespace Shell.Controllers
{
    public class StoreController : Controller
    {
        StoreRepository storeRepo = new StoreRepository();

        // GET: Store
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "Title,Description,Price")] CreateProductViewModel model)
        {
            var result = storeRepo.AddNewProduct(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public ActionResult Browse()
        {
            return View("Browse", storeRepo.AllProducts().Take(10));
        }

        [HttpPost]
        public ActionResult Browse(string searchString)
        {
            var model = storeRepo.AllProducts(searchString).Take(10);

            if (new HttpRequestWrapper(System.Web.HttpContext.Current.Request).IsAjaxRequest())
            {
                Debug.WriteLine("IsAjax");
                return PartialView("_Listings", model);
            }

            return View("Browse", model);
        }
    }
}