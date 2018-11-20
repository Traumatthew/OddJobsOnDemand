using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddJobsOnDemand.Models
{
    public class CustomerAccountViewModel
    {
        public Customer cust { get; set; }

        public List<JobRequests> jobRequests { get; set; }

        public List<Customer> customers { get; set; }

        public AccountDetails_Customer account { get; set; }

        public List<AccountDetails_Customer> accounts { get; set; }

        public string key = Keys.GoogleKey;

        public string srcKey = "https://maps.googleapis.com/maps/api/js?libraries=places&key=" + Keys.GoogleKey + "&callback=initMap";

        public GeoLocations geo { get; set; }
    }
}