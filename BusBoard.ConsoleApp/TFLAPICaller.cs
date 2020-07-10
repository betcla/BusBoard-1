using System.Net;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class PostcodesAPICaller
    {
        private RestClient Client = new RestClient("https://api.postcodes.io");
        public IRestResponse GetLongLatFromPostcode(string postcode)
        {
            var request = new RestRequest("postcodes/{postcode}", DataFormat.Json);
            request.AddUrlSegment("postcode", postcode);
            var response = Client.Get(request);
            return response;
        }
    }

    class TFLAPICaller
    {
        private RestClient Client = new RestClient("https://api.tfl.gov.uk");
        public IRestResponse GetBusesFromStopCode(string stopCode)
        {
            var request = new RestRequest("StopPoint/{stopCode}/Arrivals", DataFormat.Json);
            request.AddParameter("app_id", "7d0152bc");
            request.AddParameter("app_key", "9c228e7ec36f4500b944f2d79bf9d16f");
            request.AddUrlSegment("stopCode", stopCode);
            
            var response = Client.Get(request);
            return response;
        }
        
        public IRestResponse GetStopCodeFromLocation(Location location)
        {
            var request = new RestRequest("StopPoint", DataFormat.Json);
            request.AddParameter("stopTypes", "NaptanPublicBusCoachTram");
            request.AddParameter("app_id", "7d0152bc");
            request.AddParameter("app_key", "9c228e7ec36f4500b944f2d79bf9d16f");
            request.AddParameter("lat", location.latitude);
            request.AddParameter("lon", location.longitude);
            
            var response = Client.Get(request);
            return response;
        }
    }
}