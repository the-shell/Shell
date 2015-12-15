using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Shell.DAL;
using Shell.Models;
using Shell.Models.Repository;
using Shell.Models.Services;
using Shell.UI.ViewModels.Organisation;
using Shell.Utils;
using System.Diagnostics;

namespace Shell.UI.Controllers
{
    
    public class OrganisationController : Controller
    {
        private readonly IOrganisationService _organisationService;
        private readonly IProductService _productService;

        public OrganisationController(IOrganisationService organisationService, IProductService productService)
        {
            if (organisationService == null)
            {
                throw new ArgumentNullException("organisation repo");
            }
            if (productService == null)
            {
                throw new ArgumentNullException("product repo");
            }
            this._organisationService = organisationService;
            this._productService = productService;
        }
        // GET: Organisation
        public ActionResult Index(int id)
        {
            Session["orgId"] = id;

            var products = this._productService.GetProducts(id);

            return View();
        }

        public ActionResult Details(int id)
        {
            Debug.WriteLine(id);
            //var productList = this._productService.GetProducts(id);

            //DetailsViewModel o = new OrganisationFactory().GetViewModel(organisationService.GetOrganisation(id));

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Title,Description,Price")] CreateViewModel model)
        {
            Product p = model;
            p.Organisation = this._organisationService.GetOrganisation((int) Session["orgId"]);

            this._productService.CreateProduct(p);

            return View("Index");
        }
    }
}