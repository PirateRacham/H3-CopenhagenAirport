using System;
using System.Collections.Generic;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class ProuteOperator
    {
        public int ProuteId { get; set; }
        public int OperatorId { get; set; }

        public virtual Operator Operator { get; set; }
        public virtual Proute Proute { get; set; }
    }
}
