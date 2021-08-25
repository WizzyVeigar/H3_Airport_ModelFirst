using H3_Airport_ModelFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Airport_ModelFirst
{
    class AirportManager
    {
        H3_Airport_ModelFirstContext context;

        public List<Route> GetRoutes()
        {
            using (context = new H3_Airport_ModelFirstContext())
            {
                var routes = context.Routes.Include(x => x.FromAirport).Select(x => new Route { FromAirport = x.FromAirport, ToAirport = x.ToAirport }).AsEnumerable().ToList();


                          //.Include(lu => lu.License.Product)
                          //.Where(lu => lu.User.Id == 1)
                          //.Select(lu => new { lic = lu.License, prod = lu.License.Product })
                          //.AsEnumerable()  // Here we have forced the SQL to include the product too
                          //.Select(lu => lu.lic)
                          //.ToList();

                Console.WriteLine(routes);
                return null;
            }
        }
    }
}
