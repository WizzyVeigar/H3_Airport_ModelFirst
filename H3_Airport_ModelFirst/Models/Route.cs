using System;
using System.Collections.Generic;

#nullable disable

namespace H3_Airport_ModelFirst.Models
{
    public partial class Route
    {
        public int RouteId { get; set; }
        public int OperatorAirlineId { get; set; }
        public int OwnerAirlineId { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        public int PlaneId { get; set; }

        public virtual Airline OperatorAirline { get; set; }
        public virtual Airline OwnerAirline { get; set; }
        public virtual Airport FromAirport { get; set; }
        public virtual Airport ToAirport { get; set; }
        public virtual Plane Plane { get; set; }
    }
}
