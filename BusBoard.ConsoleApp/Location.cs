using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.UI;

namespace BusBoard.ConsoleApp
{
    public class Location
    {
        public string latitude { get; }
        public string longitude { get; }

        public Location(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Location() { }
    }

    public class DummyLocation
    {
        public Dictionary<string, string> result { get; }

        public DummyLocation(Dictionary<string, string> result)
        {
            this.result = result;
        }
    }
}