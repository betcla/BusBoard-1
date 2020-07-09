using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

      var client = new RestClient("https://api.tfl.gov.uk");

      var request = new RestRequest("StopPoint/Mode/bus/Disruption", DataFormat.Json);
      request.AddParameter("app_id", "7d0152bc");
      request.AddParameter("app_key", "9c228e7ec36f4500b944f2d79bf9d16f");

      var response = client.Get(request);
    }
  }
}
