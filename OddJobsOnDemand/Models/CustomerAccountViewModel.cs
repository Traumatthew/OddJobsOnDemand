using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class CustomerAccountViewModel
    {
        public Customer cust { get; set; }
        public List<JobRequests> requests { get; set; }
        public List<Customer> customers { get; set; }
        public string key = Key.GKey;
        public string srcKey = "https://maps.googleapis.com/maps/api/js?libraries=places&key=" + Key.GKey + "&callback=initMap";
        public GeoLocations geo { get; set; }
    }
}