using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class ContractorCustomerAccountsViewModel
    {
        public CustomerAccountViewModel CustViewModel { get; set; }
        public Contractor cont { get; set; }
    }
}