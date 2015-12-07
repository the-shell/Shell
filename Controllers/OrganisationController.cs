using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shell.DAL;
using Shell.Models;
using Shell.ViewModels.Organisation;

namespace Shell.Controllers
{
    public class OrganisationController : Controller
    {
        StoreRepository repo = new StoreRepository();
        // GET: Organisation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")] CreateVM model)
        {
            int orgId = repo.CreateOrganisation(model);
            return RedirectToAction("Details", new { Id = orgId});
        }

        public ActionResult Details(int Id)
        {
            
                Organisation o = repo.GetOrganisation(Id);
                return View(o);
        
            
            
        }
    }
}