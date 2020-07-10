using System;

namespace BusBoard.ConsoleApp
{
    class BusStop
    {
        public string destinationName;
        public string lineId;
        public DateTime expectedArrival;

        public override string ToString()
        {
            return $"Line: {lineId}\nTo: {destinationName}\nArriving at: {expectedArrival}";
        }
    }
}