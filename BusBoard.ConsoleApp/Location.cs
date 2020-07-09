using System.Linq.Expressions;

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
    }
}