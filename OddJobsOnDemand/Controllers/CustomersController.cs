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
                JobRequestsViewModel viewModel = new JobRequestsViewModel() { cust = customer, JobRequests = jobs };
                //var acctDet = db.AccountDetails_Customer.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
                //CustomerAccountViewModel viewModel = new CustomerAccountViewModel() { cust = customer, account = accountDet, jobs = JobReq };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Initial");
            }
        }
        
        //GET
        public ActionResult Initial()
        {
            AccountDetails_Customer account = new AccountDetails_Customer();
            return View(account);
        }

        //POST
        [HttpPost]
        public ActionResult Initial(AccountDetails_Customer account)
        {
            AccountDetails_Customer newJob = new AccountDetails_Customer();
            var cust = GetCustomer();
            newJob.CustomerId = cust.CustomerId;
            newJob.date = account.date;
            db.AccountDetails_Customers.Add(newJob);
            return View();
        }
    }
}