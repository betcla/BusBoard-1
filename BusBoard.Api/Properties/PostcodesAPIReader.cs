using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class PostcodesAPIReader
    {
        public Location GetLocation(IRestResponse response)
        {
            var location = JsonConvert.DeserializeObject<PostcodesResponses>(response.Content).result;
            
            return location;
        }
    }
}