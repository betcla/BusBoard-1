using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.UI;

namespace BusBoard.ConsoleApp
{
    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }

        public Location(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Location() { }
    }

    public class DummyLocation
    {
        public Location result { get; set; }

    }
}