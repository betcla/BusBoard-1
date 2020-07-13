using System;
using System.Collections.Generic;

namespace BusBoard.Api
{
    public class BusArrival
    {
        public string destinationName;
        public string lineId;
        public DateTime expectedArrival;

        public override string ToString()
        {
            return $"Line: {lineId}\nTo: {destinationName}\nArriving at: {expectedArrival}";
        }
    }

    public class BusStop
    {
        public string naptanID { get; set; }
        public string distance { get; set; }
        public string commonName { get; set; }
        public List<BusArrival> Arrivals { get; set; }
    }

    public class StopCodeResponses
    {
        public List<BusStop> stopPoints { get; set; }
    }
}