using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
    class BusStop : IComparable
    {
        public string destinationName;
        public string lineId;
        public string expectedArrival;
        public int CompareTo(object comparePart)
        {
            if (comparePart == null) return 1;

            BusStop otherBusStop = comparePart as BusStop;
            if (otherBusStop != null)
                return this.expectedArrival.CompareTo(otherBusStop.expectedArrival);
            else
                throw new ArgumentException("Object is not a BusStop");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient("https://api.tfl.gov.uk");

            var request = new RestRequest("StopPoint/Mode/bus/Disruption", DataFormat.Json);
            request.AddParameter("app_id", "7d0152bc");
            request.AddParameter("app_key", "9c228e7ec36f4500b944f2d79bf9d16f");

            var response = client.Get(request);

            var busStopList = JsonConvert.DeserializeObject<List<BusStop>>(response.Content);

            busStopList.Sort();
        }
    }
}