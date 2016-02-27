using Microsoft.AspNet.Identity;
using Shell.DAL;
using Shell.Identity;
using Shell.Models;
using Shell.Models.Repository;
using Shell.Repository;
using Shell.Services;
using Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Shell.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessService _organisationService;
        private readonly UserManager<User> _userManager;
        private readonly CustomUserStore _userStore;

        public HomeController(IBusinessService organisationService, UserManager<User> manager, CustomUserStore store)
        {
            _organisationService = organisationService;
            _userManager = manager;
            _userStore = store;
        }

        public ActionResult Index()
        {
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