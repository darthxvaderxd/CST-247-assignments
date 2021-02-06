using activity3part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace activity3part1.Controllers
{
    public class CustomerController : Controller
    {
        protected List<CustomerModel> customers = new List<CustomerModel>();


        public CustomerController()
        {
            customers.Add(new CustomerModel(1, "Richard", 39));
            customers.Add(new CustomerModel(2, "Katie", 39));
            customers.Add(new CustomerModel(3, "Josiah", 17));
            customers.Add(new CustomerModel(4, "RJ", 14));
            customers.Add(new CustomerModel(5, "Jeremiah", 12));
            customers.Add(new CustomerModel(6, "Rebekah", 3));
        }

        // GET: Customer
        public ActionResult Index()
        {
            Tuple<List<CustomerModel>, CustomerModel> data = new Tuple<List<CustomerModel>, CustomerModel>(this.customers, this.customers.ElementAt(0));

            // return View("CustomerView", data);
            return View("CustomerAjaxView", data);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(int ID)
        {
            CustomerModel customer =  ID < this.customers.Count
                ? this.customers.ElementAt(ID)
                : this.customers.ElementAt(0);

            Tuple<List<CustomerModel>, CustomerModel> data = new Tuple<List<CustomerModel>, CustomerModel>(this.customers, customer);
            
            // return View("CustomerView", data);
            return PartialView("_CustomerDetails", data.Item2);
        }

        [HttpPost]
        public string GetMoreInfo(int ID)
        {
            return "Customer ID was => " + ID;
        }
    }
}