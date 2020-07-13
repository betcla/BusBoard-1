using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.Models
{
    public class PostcodesAPI
    {
        private PostcodesAPICaller Caller { get; set; } = new PostcodesAPICaller();
        private PostcodesAPIReader Reader { get; set; } = new PostcodesAPIReader();

        public Location GetLocation(string postcode)
        {
            return Reader.GetLocation(Caller.GetLocationFromPostcode(postcode));
        }
    }
}