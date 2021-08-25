using System;
using System.Collections.Generic;

#nullable disable

namespace H3_Airport_ModelFirst.Models
{
    public partial class Airport
    {
        public Airport()
        {
            RouteFromAirports = new HashSet<Route>();
            RouteToAirports = new HashSet<Route>();
        }

        public int AirportId { get; set; }
        public string Iata { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Route> RouteFromAirports { get; set; }
        public virtual ICollection<Route> RouteToAirports { get; set; }
    }
}
