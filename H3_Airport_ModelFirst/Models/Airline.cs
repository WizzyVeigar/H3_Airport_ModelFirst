using System;
using System.Collections.Generic;

#nullable disable

namespace H3_Airport_ModelFirst.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Planes = new HashSet<Plane>();
            RouteOperatorAirlines = new HashSet<Route>();
            RouteOwnerAirlines = new HashSet<Route>();
        }

        public int AirlineId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }
        public virtual ICollection<Route> RouteOperatorAirlines { get; set; }
        public virtual ICollection<Route> RouteOwnerAirlines { get; set; }
    }
}
