using System;
using System.Collections.Generic;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class Flight
    {
        public Flight()
        {
            FlightOperator = new HashSet<FlightOperator>();
        }

        public int Id { get; set; }
        public int TravelTime { get; set; }
        public int ProuteId { get; set; }

        public virtual ICollection<FlightOperator> FlightOperator { get; set; }
    }
}
