using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class JobRequestsViewModel
    {
        public List<Customer> customers { get; set; }
        public List<JobRequests> JobRequests { get; set; }
        public Customer cust { get; set; }
    }
}