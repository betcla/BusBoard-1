﻿using System;
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

            var stops = tflReader.GetStops(tflCaller.GetStopCodeFromLocation(loc));
            foreach (var stop in stops.Take(2))
            {
                var response = tflCaller.GetBusesFromStopCode(stop.naptanID);

                stop.Arrivals = tflReader.GetArrivals(response);
                Console.WriteLine($"Next 5 buses at stop {stop.commonName}:");
                foreach (var bus in stop.Arrivals.Take(5))
                {
                    Console.WriteLine(bus);
                }
            }
        }
    }
}