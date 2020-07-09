using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class APIReader
    {
        public static IEnumerable<BusStop> GetFirstFewStops(IRestResponse response, int few)
        {
            var busStopList = JsonConvert.DeserializeObject<List<BusStop>>(response.Content);
            busStopList.Sort();
            var firstFewStops = busStopList.Take(few);
            return firstFewStops;
        }

        public static Location GetLocation(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<Location>(response.Content);
        }
    }
}