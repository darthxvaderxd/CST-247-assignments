using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity2Part1.Models;

namespace Activity2Part1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();
            users.Add(new UserModel("Bob Ross", "bross@ross.com", "555-123-4567"));
            users.Add(new UserModel("Rick Ross", "rross@ross.com", "555-123-4568"));
            users.Add(new UserModel("Richard Williamson", "rwilliamson@ross.com", "555-123-4569"));

            return View("Test", users);
        }
    }
}