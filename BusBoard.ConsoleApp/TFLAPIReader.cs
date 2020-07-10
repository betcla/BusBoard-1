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
            var location = JsonConvert.DeserializeObject<PostcodesResponses>(response.Content).result;
            
            return location;
        }
    }

    class TFLAPIReader
    {
        public static IEnumerable<BusArrival> GetFirstFewStops(IRestResponse response, int few)
        {
            var busStopList = JsonConvert.DeserializeObject<List<BusArrival>>(response.Content);
            busStopList.Sort((x,y) => x.expectedArrival.CompareTo(y.expectedArrival));
            var firstFewStops = busStopList.Take(few);
            return firstFewStops;
        }
        
        public static IEnumerable<StopCode> GetStopCode(IRestResponse response, int few)
        {
            var stopCodeResponseList = JsonConvert.DeserializeObject<List<StopCodeResponses>>(response.Content);
            var stopCodeList = stopCodeResponseList.Select(x => x.stopPoints).ToList();            
            stopCodeList.Sort((x, y) => x.distance.CompareTo(y.distance));
            var firstFewStops = stopCodeList.Take(few);
            return firstFewStops;
        }
    }
}