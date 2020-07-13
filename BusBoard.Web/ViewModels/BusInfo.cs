using BusBoard.Api;
using System;
using System.Collections.Generic;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode)
    {
      PostCode = postCode;
      
    }

    public string PostCode { get; set; }

    public List<BusArrival> BusArrivals { get; set; }
    public List<BusStop> BusStops { get; set; }

  }
}