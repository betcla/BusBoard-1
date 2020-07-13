using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.Models
{
    public class TFLAPI
    {
        private TFLAPICaller Caller { get; set; } = new TFLAPICaller();
        private TFLAPIReader Reader { get; set; } = new TFLAPIReader();

        public List<BusStop> GetStops(Location loc)
        {
            var stops = Reader.GetStops(Caller.GetStopCodeFromLocation(loc));
            SetArrivals(stops);
            return stops;
        }

        private void SetArrivals(List<BusStop> stops)
        {
            foreach (var stop in stops)
            {
                var response = Caller.GetBusesFromStopCode(stop.naptanID);

                stop.Arrivals = Reader.GetArrivals(response);
            }
        }
    }
}