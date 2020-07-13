using RestSharp;

namespace BusBoard.Api
{
    public class PostcodesAPICaller
    {
        private RestClient Client = new RestClient("https://api.postcodes.io");
        public IRestResponse GetLocationFromPostcode(string postcode)
        {
            var request = new RestRequest("postcodes/{postcode}", DataFormat.Json);
            request.AddUrlSegment("postcode", postcode);
            var response = Client.Get(request);
            return response;
        }
    }
}