using System;
using System.Linq;

namespace H3_CopenhagenAirport_DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            using (var context = new AirportDBContext())
            {
                var flight = context.Flight.Where(f => f.Id == 1).ToList();
                foreach (var item in flight)
                {
                    Console.WriteLine("Travel time: " + item.TravelTime);
                    foreach (var fo in item.FlightOperator)
                    {
                        Console.WriteLine("Departure Time: " + fo.Liftoff);
                        Console.WriteLine("Arrival Time: "  + fo.Touchdown);
                        Console.WriteLine("Plane Operator: " + fo.Operator.Name);
                    }
                    var route = context.Proute.Where(p => p.Id == item.ProuteId).ToList();
                    foreach (var proute in route)
                    {
                        Console.WriteLine("Origin: " + proute.Origin);
                        Console.WriteLine("Destination: " + proute.Destination);
                    }

                }
            }
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
