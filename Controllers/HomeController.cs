using Shell.Models.Repository;
using Shell.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shell.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IOrganisationService _organisationService;

        public HomeController()//IOrganisationService OrganisationService)
        {
            //if (OrganisationService == null)
            //    throw new ArgumentNullException("orgService");

            //_organisationService = OrganisationService;
        }

        public ActionResult Index()
        {
            //var LatestOrganisations = _organisationService.GetLatestOrganisations();
            //return View(new HomeViewModel
            //{
            //    OrganisationNames = LatestOrganisations.Select(x => x.Name).ToList()
            //});
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}