using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class TFLAPIReader
    {
        public IEnumerable<BusArrival> GetFirstFewStops(IRestResponse response, int few)
        {
            var busStopList = JsonConvert.DeserializeObject<List<BusArrival>>(response.Content);
            busStopList.Sort((x,y) => x.expectedArrival.CompareTo(y.expectedArrival));
            var firstFewStops = busStopList.Take(few);
            return firstFewStops;
        }
        
        public IEnumerable<BusStop> GetFirstFewStopCodes(IRestResponse response, int few)
        {
            var stopCodeList = JsonConvert.DeserializeObject<StopCodeResponses>(response.Content);
            stopCodeList.stopPoints.Sort((x, y) => x.distance.CompareTo(y.distance));
            var firstFewStops = stopCodeList.stopPoints.Take(few);
            return firstFewStops;
        }
    }
}