using System;
using System.Collections.Generic;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class FlightOperator
    {
        public int OperatorId { get; set; }
        public int FlightId { get; set; }
        public int Liftoff { get; set; }
        public int Touchdown { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Operator Operator { get; set; }
    }
}
