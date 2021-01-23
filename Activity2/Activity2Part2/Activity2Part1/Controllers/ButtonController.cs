using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity2Part1.Models;

namespace Activity2Part1.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();



        // GET: Button
        public ActionResult Index()
        {
            if (buttons.Count < 1)
            {
                buttons.Add(new ButtonModel(false));
                buttons.Add(new ButtonModel(false));
            }
            return View("Button", buttons);
        }

        public ActionResult OnButtonClick(string mine)
        {
            // get the button
            ButtonModel button;
            if (mine == "1")
            {
                button = buttons.ElementAt(0);
            } else
            {
                button = buttons.ElementAt(1);
            }

            // toggle the state
            button.State = !button.State;

            return View("Button", buttons);
        }
    }
}