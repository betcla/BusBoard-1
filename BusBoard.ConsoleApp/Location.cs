using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.UI;

namespace BusBoard.ConsoleApp
{
    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class PostcodesResponses
    {
        public Location result { get; set; }

    }
}