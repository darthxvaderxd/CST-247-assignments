using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    [CustomAction]
    public class TestController : Controller
    {
        // GET: Test
        [HttpGet]
        [CustomAuthorization]
        public string Index()
        {
            return "hello from test";
        }
    }
}