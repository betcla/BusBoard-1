using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.Models
{
    public class TFLAPI
    {
        private TFLAPICaller Caller { get; set; } = new TFLAPICaller();
        private TFLAPIReader Reader { get; set; } = new TFLAPIReader();
        
        public IEnumerable<BusStop> GetLocation(Location loc) {
            return Reader.GetFirstFewStopCodes(Caller.GetStopCodeFromLocation(loc), 2);
        }
    }
}