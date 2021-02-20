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
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            // Validate the Form POST
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            SecurityService service = new SecurityService();
            Boolean result = service.Authenticate(model);

            if (result == true)
            {
                return View("LoginPassed");
            }

            return View("LoginFailed");
        }

    }
}