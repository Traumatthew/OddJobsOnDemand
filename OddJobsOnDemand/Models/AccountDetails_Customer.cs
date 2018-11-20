using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class AccountDetails_Customer
    {
        [Key]
        public int CustomerAccountId { get; set; }

        [ForeignKey("Customers")]
        [Display(Name ="Customer Id")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        [Display(Name ="Requested Job Date")]
        public DateTime date { get; set; }
    }
}