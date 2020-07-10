using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            var stopCode = "490008660N";
            var postcode = "NW51TL";
            Console.WriteLine("Welcome, please enter a stopcode (Hint: choose 490008660N)");
            //var stopCode = Console.ReadLine();

            var loc = PostcodesAPIReader.GetLocation(PostcodesAPICaller.GetLongLatFromPostcode(postcode));
            Console.WriteLine(loc.latitude);
            
            var response = TFLAPICaller.GetBusesFromStopCode(stopCode);

            var few = 5;
            var firstFewStops = TFLAPIReader.GetFirstFewStops(response, few);
            foreach (var stop in firstFewStops)
            {
                Console.WriteLine(stop);
            }
        }
    }
}