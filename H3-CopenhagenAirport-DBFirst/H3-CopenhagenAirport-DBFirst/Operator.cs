using System;
using System.Collections.Generic;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class Operator
    {
        public Operator()
        {
            FlightOperator = new HashSet<FlightOperator>();
            ProuteOperator = new HashSet<ProuteOperator>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FlightOperator> FlightOperator { get; set; }
        public virtual ICollection<ProuteOperator> ProuteOperator { get; set; }
    }
}
