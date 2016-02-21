using Microsoft.AspNet.Identity;
using Shell.Identity;
using Shell.Models;
using Shell.Services;
using Shell.ViewModels;
using System;
using System.Web.Mvc;

namespace Shell.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrganisationService _organisationService;
        private readonly UserManager<User> _userManager;
        private readonly CustomUserStore _userStore;

        public HomeController(IOrganisationService organisationService, UserManager<User> manager, CustomUserStore store)
        {
            _organisationService = organisationService;
            _userManager = manager;
            _userStore = store;
        }

        public ActionResult Index()
        {
            CreateOrganisationViewModel a = new CreateOrganisationViewModel
            {
                Name = "First"
            };
            a.UserId = User.Identity.GetUserId();
            if (User.Identity.IsAuthenticated)
            {
                _organisationService.Create(a);
            }
            
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