using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    [CustomAction]
    public class LoginController : Controller
    {
        private List<UserModel> users;
        public LoginController()
        {
            users = new List<UserModel>();
            UserModel user1 = new UserModel();
            user1.Password = "testPassword@1";
            user1.Username = "bob";

            UserModel user2 = new UserModel();
            user2.Password = "12345";
            user2.Username = "bill";

            users.Add(user1);
            users.Add(user2);
        }

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

        [HttpGet]
        [CustomAuthorization]
        public string Protected()
        {
            return "you can csee this now";
        }

        [HttpGet]
        public string GetUsers()
        {
            MemoryCache cache = MemoryCache.Default;
            string cachedUsers = (string)cache.Get("Users");
            if (cachedUsers == null)
            {
                Debug.WriteLine("Cache entry for users missed");
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(60)
                };
                cachedUsers = JsonConvert.SerializeObject(users);
                cache.Set("Users", cachedUsers, policy);
            }
            else
            {
                Debug.WriteLine("Cache entry used");
            }

            return cachedUsers;
        }
    }
}