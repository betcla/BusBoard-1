using System.Net;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class PostcodesAPICaller
    {
        public static IRestResponse GetLongLatFromPostcode(string postcode)
        {
            var client = new RestClient("https://api.postcodes.io");

            var request = new RestRequest("postcodes/{postcode}", DataFormat.Json);
            request.AddUrlSegment("postcode", postcode);
            var response = client.Get(request);
            return response;
        }
    }

    class TFLAPICaller
    {
        public static IRestResponse GetBusesFromBusCode(string stopCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk");

            var request = new RestRequest("StopPoint/{stopCode}/Arrivals", DataFormat.Json);
            request.AddParameter("app_id", "7d0152bc");
            request.AddParameter("app_key", "9c228e7ec36f4500b944f2d79bf9d16f");
            request.AddUrlSegment("stopCode", stopCode);
            
            var response = client.Get(request);
            return response;
        }
    }
}