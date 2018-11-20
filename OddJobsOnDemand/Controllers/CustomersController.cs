using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OddJobsOnDemand.Models;

namespace OddJobsOnDemand.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public Customer GetCustomer()
        {
            var customer = db.Customers.Where(x => x.Email == HttpContext.User.Identity.Name).FirstOrDefault();
            return customer;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var JobReq = db.JobRequests.ToList();
            var customer = GetCustomer();
            bool found = false;
            foreach(var item in JobReq)
            {
                if(item.CustomerId == customer.CustomerId)
                {
                    found = true;
                }
            }
            if (found == true)
            {
                var jobs = db.JobRequests.Where(x => x.CustomerId == customer.CustomerId).ToList();
            }
            return View();
        }
    }
}