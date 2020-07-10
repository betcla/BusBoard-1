using System.Collections.Generic;
using System.Linq;
using BusBoard.ConsoleApp;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class PostcodesAPIReader
    {
        public static Location GetLocation(IRestResponse response)
        {
            var a = JsonConvert.DeserializeObject<DummyLocation>(response.Content).result;
            
            return new Location((string)a["latitude"], (string)a["longitude"]);  //new Location("", ""); /*a.latitude, a.longitude);*/
        }
    }

    class TFLAPIReader
    {
        public static IEnumerable<BusStop> GetFirstFewStops(IRestResponse response, int few)
        {
            var busStopList = JsonConvert.DeserializeObject<List<BusStop>>(response.Content);
            busStopList.Sort((x,y) => x.expectedArrival.CompareTo(y.expectedArrival));
            var firstFewStops = busStopList.Take(few);
            return firstFewStops;
        }
    }
}