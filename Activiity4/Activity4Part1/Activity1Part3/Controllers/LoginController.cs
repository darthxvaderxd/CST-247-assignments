using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using Activity1Part3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        private static MyLogger1 logger = MyLogger1.GetInstance();

        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            logger.Info("Entering LoginController.DoLogin()");

            // Validate the Form POST
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(model));

            try
            {
                SecurityService service = new SecurityService();
                Boolean result = service.Authenticate(model);

                if (result == true)
                {
                    logger.Info("Exit LoginController.DoLogin() with login passing");
                    return View("LoginPassed");
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception LoginController.DoLogin()" + e.Message);
            }

            logger.Info("Exit LoginController.DoLogin() with login failing");
            return View("LoginFailed");
        }

    }
}