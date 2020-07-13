using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.Models
{
    public class TFLAPI
    {
        private TFLAPICaller Caller { get; set; } = new TFLAPICaller();
        private TFLAPIReader Reader { get; set; } = new TFLAPIReader();

        public IEnumerable<BusStop> GetStops(Location loc)
        {
            return Reader.GetStops(Caller.GetStopCodeFromLocation(loc));
        }

        public void SetArrivals(List<BusStop> stops)
        {
            foreach (var stop in stops)
            {
                var response = Caller.GetBusesFromStopCode(stop.naptanID);

                stop.Arrivals = Reader.GetArrivals(response);
            }
        }
    }
}