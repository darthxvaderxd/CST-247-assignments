/**
 *        file: Controllers/BibleVerseController.cs
 * description: controller for our applicaiton
 *      author: Richard Williamson
 *       notes: none
 */

using BibleVerseApplication.Models;
using BibleVerseApplication.Services;
using BibleVerseApplication.Services.Data;
using BibleVerseApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApplication.Controllers
{
    public class BibleVerseController : Controller
    {
        ILogger Logger = Util.GetLogger();
        BibleVerseDAO service = new BibleVerseDAO();

        // GET: BibleVerse
        public ActionResult Index()
        {
            Logger.Info("BibleVerseController Index() called");
            return View();
        }

        // POST: BibleVerese/CreateVerse
        [HttpPost]
        [Obsolete]
        public ActionResult Index(BibleVerse verse)
        {
            Logger.Info("BibleVerseController CreateVerse() started");

            // validate the data
            if (!ModelState.IsValid)
            {
                return View("Index", verse);
            }

            // save the BibleVerse
            service.AddVerse(verse);

            Logger.Info("BibleVerseController CreateVerse() ended");
            return View("CreateVerse", verse);
        }
    }
}