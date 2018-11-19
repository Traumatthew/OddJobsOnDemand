using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class JobRequest
    {
        [Key]
        public int JobId { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        [Required(ErrorMessage = "Location Required")]
        public string Location { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A Date is required for request")]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Time Required")]
        public string Time { get; set; }
        public double Estiamte { get; set; }
        public bool Complete { get; set; }
        [Display(Name = "Job Description")]
        public string Details { get; set; }
    }
}