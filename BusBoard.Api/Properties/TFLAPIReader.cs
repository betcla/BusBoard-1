using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class TFLAPIReader
    {
        public List<BusArrival> GetArrivals(IRestResponse response)
        {
            var busStopList = JsonConvert.DeserializeObject<List<BusArrival>>(response.Content);
            busStopList.Sort((x,y) => x.expectedArrival.CompareTo(y.expectedArrival));
            return busStopList;
        }
        
        public List<BusStop> GetStops(IRestResponse response)
        {
            var stopCodeList = JsonConvert.DeserializeObject<StopCodeResponses>(response.Content);
            stopCodeList.stopPoints.Sort((x, y) => x.distance.CompareTo(y.distance));
            return stopCodeList.stopPoints;
        }
    }
}