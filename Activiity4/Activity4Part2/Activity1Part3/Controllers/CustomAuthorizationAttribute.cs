using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                // auth failed, redirect to login page
                filterContext.HttpContext.Response.Redirect(urlHelper.Action("Index", "Login"), true);
            }
        }
    }
}