using System;
using System.Collections.Generic;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class Proute
    {
        public Proute()
        {
            ProuteOperator = new HashSet<ProuteOperator>();
        }

        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

        public virtual Airport DestinationNavigation { get; set; }
        public virtual Airport OriginNavigation { get; set; }
        public virtual ICollection<ProuteOperator> ProuteOperator { get; set; }
    }
}
