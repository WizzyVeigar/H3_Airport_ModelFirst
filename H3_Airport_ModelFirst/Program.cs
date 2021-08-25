using H3_Airport_ModelFirst.Models;
using System;

namespace H3_Airport_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AirportManager manager = new AirportManager();

            foreach (Route item in manager.GetRoutes())
            {
                Console.WriteLine(item.ToAirport.Name +"    " + item.FromAirport.Name);
            } 
        }
    }
}
