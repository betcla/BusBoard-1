﻿using System;

namespace BusBoard.ConsoleApp
{
    class BusArrival
    {
        public string destinationName;
        public string lineId;
        public DateTime expectedArrival;

        public override string ToString()
        {
            return $"Line: {lineId}\nTo: {destinationName}\nArriving at: {expectedArrival}";
        }
    }

    public class StopCode
    {
        public string naptanID { get; set; }
        public string distance { get; set; }
    }

    public class StopCodeResponses
    {
        public StopCode stopPoints { get; set; }
    }
}