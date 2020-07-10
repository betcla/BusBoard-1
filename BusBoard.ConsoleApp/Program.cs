using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
            
            //var stopCode = "490008660N";
            var postcode = "NW51TL";
            //Console.WriteLine("Welcome, please enter a stopcode (Hint: choose 490008660N)");
            //var stopCode = Console.ReadLine();
            
            
            var tflReader = new TFLAPIReader();
            var postcodesReader = new PostcodesAPIReader();
            var tflCaller = new TFLAPICaller();
            var postcodesCaller = new PostcodesAPICaller();
            
            var loc = postcodesReader.GetLocation(postcodesCaller.GetLongLatFromPostcode(postcode));
            //Console.WriteLine(loc.latitude);

            var stopCode = tflReader.GetFirstFewStopCodes(tflCaller.GetStopCodeFromLocation(loc), 1);

            var response = tflCaller.GetBusesFromStopCode(stopCode.First().naptanID);

            var few = 5;
            var firstFewStops = tflReader.GetFirstFewStops(response, few);
            foreach (var stop in firstFewStops)
            {
                Console.WriteLine(stop);
            }
        }
    }
}