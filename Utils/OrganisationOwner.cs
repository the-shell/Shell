using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shell.DAL;
using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shell.Utils
{
    public class OrganisationOwner : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
                return false;

            var rd = httpContext.Request.RequestContext.RouteData;

            string id = (string) rd.Values["id"];
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            Organisation org = new ApplicationDbContext().Organisations.Where(o => o.Id.ToString() == id).First();

            return org.OwnerId == userId;
        }
    }
}