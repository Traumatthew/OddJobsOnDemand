using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Phone { get; set; }

        public string ContractorName { get; set; }

        public string AreaOfExpertise { get; set; }

        public string Email { get; set; }

        public string ContractorStreet { get; set; }

        public string ContractorState { get; set; }

        public string ContractorCity { get; set; }

        public string ContractorZip { get; set; }

        public string lat { get; set; }

        public string lng { get; set; }


    }
}