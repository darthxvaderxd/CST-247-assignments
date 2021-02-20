/**
 *        file: Controllers/BibleVerseController.cs
 * description: controller for our applicaiton
 *      author: Richard Williamson
 *       notes: none
 */

using BibleVerseApplication.Models;
using BibleVerseApplication.Services;
using BibleVerseApplication.Services.Business;
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
        private ILogger Logger = Util.GetLogger();
        private VerseService Service = new VerseService();

        // GET: BibleVerse
        public ActionResult Index()
        {
            Logger.Info("BibleVerseController Index() called");
            return View("CreateVerse");
        }

        // POST: BibleVerese/CreateVerse
        [HttpPost]
        [Obsolete]
        public ActionResult Index(BibleVerse bibleVerse)
        {
            Logger.Info("BibleVerseController CreateVerse() started");

            if (bibleVerse != null)
            {
                Logger.Debug("Verse Testament => " + (bibleVerse.Testament != null ? bibleVerse.Testament : "Null"));
                Logger.Debug("Verse Book => " + (bibleVerse.Book != null ? bibleVerse.Book : "Null"));
                Logger.Debug("Verse Chapter => " + (bibleVerse.Chapter != null ? bibleVerse.Chapter : "Null"));
                Logger.Debug("Verse Verse => " + (bibleVerse.Verse != null ? bibleVerse.Verse : "Null"));
                Logger.Debug("Verse Text => " + (bibleVerse.Text != null ? bibleVerse.Text : "Null"));
            }

            // validate the data
            if (!ModelState.IsValid)
            {
                return View("CreateVerse", bibleVerse);
            }

            // save the BibleVerse
            Service.AddVerse(bibleVerse);

            Logger.Info("BibleVerseController CreateVerse() ended");
            return View("ViewVerse", bibleVerse);
        }


        [HttpGet]
        public ActionResult Search()
        {
            Logger.Info("BibleVerseController Search()");
            return View("Search");
        }

        // POST: BibleVerese/Search
        [HttpPost]
        [Obsolete]
        public ActionResult Search(Search search)
        {
            Logger.Info("BibleVerseController Search() started");

            if (search != null)
            {
                Logger.Debug("Verse Testament => " + (search.Testament != null ? search.Testament : "Null"));
                Logger.Debug("Verse Book => " + (search.Book != null ? search.Book : "Null"));
                Logger.Debug("Verse Chapter => " + (search.Chapter != null ? search.Chapter : "Null"));
                Logger.Debug("Verse Verse => " + (search.Verse != null ? search.Verse : "Null"));
            }

            // validate the data
            if (!ModelState.IsValid)
            {
                return View("Search", search);
            }

            // save the BibleVerse
            List<BibleVerse> verses = Service.SearchVerse(search);

            Logger.Info("BibleVerseController Search() ended");
            return View("ViewVerses", verses);
        }
    }
}