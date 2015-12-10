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

namespace Shell.UI.Controllers
{
    [OrganisationOwner]
    public class OrganisationController : Controller
    {
        private readonly OrganisationRepository _repository;

        public OrganisationController(OrganisationRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repo");
            }
            this._repository = repository;
        }
        // GET: Organisation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")] CreateViewModel model)
        {
            var organisationService = new OrganisationService(this._repository);

            int orgId = organisationService.CreateOrganisation(model);

            return RedirectToAction("Details", new { id = orgId });
        }

        public ActionResult Details(int id)
        {
            var organisationService = new OrganisationService(this._repository);

            DetailsViewModel o = organisationService.GetOrganisation(id);

            return View(o);
        }
    }
}