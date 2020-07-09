using System.Net;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class APICaller
    {
        public static IRestResponse GetBusesFromBusCode(string stopCode)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient("https://api.tfl.gov.uk");

            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", DataFormat.Json);
            request.AddParameter("app_id", "7d0152bc");
            request.AddParameter("app_key", "9c228e7ec36f4500b944f2d79bf9d16f");

            var response = client.Get(request);
            return response;
        }

        public static IRestResponse GetLongLatFromPostcode(string postcode)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            var client = new RestClient("https://api.postcodes.io");

            var request = new RestRequest($"postcodes/{postcode}", DataFormat.Json);
            var response = client.Get(request);
            return response;
        }
    }
}