using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusBoard.Api;
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
            
            //var stopCode = "490008660N";
            //var postcode = "NW51TL";
            Console.WriteLine("Welcome, please enter a postcode (Hint: choose NW51TL)");
            var postcode = Console.ReadLine();
            
            var tflReader = new TFLAPIReader();
            var postcodesReader = new PostcodesAPIReader();
            var tflCaller = new TFLAPICaller();
            var postcodesCaller = new PostcodesAPICaller();
            
            var loc = postcodesReader.GetLocation(postcodesCaller.GetLocationFromPostcode(postcode));

            var stopCodes = tflReader.GetFirstFewStopCodes(tflCaller.GetStopCodeFromLocation(loc)).Take(2);

            foreach (var stopCode in stopCodes)
            {
                var response = tflCaller.GetBusesFromStopCode(stopCode.naptanID);
                
                var few = 5;
                var firstFewStops = tflReader.GetFirstFewStops(response, few);
                Console.WriteLine($"Next 5 buses at stop {stopCode.commonName}:");
                foreach (var stop in firstFewStops)
                {
                    Console.WriteLine(stop);
                }
            }
        }
    }
}