using BusBoard.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public string PostCode { get; set; }
        public List<BusStop> Stops { get; set; }

        public BusInfo(List<BusStop> stops, string postCode)
        {
            PostCode = postCode;

            Stops = stops.Take(2).ToList();
            foreach (var stop in Stops)
            {
                stop.Arrivals = stop.Arrivals.Take(5).ToList();
            }
        }
    }
}