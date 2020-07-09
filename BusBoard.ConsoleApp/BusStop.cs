using System;

namespace BusBoard.ConsoleApp
{
    class BusStop : IComparable
    {
        public string destinationName;
        public string lineId;
        public DateTime expectedArrival;
        
        public int CompareTo(object comparePart)
        {
            if (comparePart == null) return 1;

            BusStop otherBusStop = comparePart as BusStop;
            if (otherBusStop != null)
                return this.expectedArrival.CompareTo(otherBusStop.expectedArrival);
            else
                throw new ArgumentException("Object is not a BusStop");
        }

        public override string ToString()
        {
            return $"Line: {lineId}\nTo: {destinationName}\nArriving at: {expectedArrival}";
        }
    }
}