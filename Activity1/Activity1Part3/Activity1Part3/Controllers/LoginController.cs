using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        SecurityService service = new SecurityService();
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            if (this.service.Authenticate(model))
            {
                return View("LoginPassed");
            }

            return View("LoginFailed");
        }

    }
}