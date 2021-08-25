using System;
using System.Collections.Generic;

#nullable disable

namespace H3_Airport_ModelFirst.Models
{
    public partial class Plane
    {
        public Plane()
        {
            Routes = new HashSet<Route>();
        }

        public int PlaneId { get; set; }
        public string Name { get; set; }
        public int AirlineId { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
