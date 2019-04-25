using System;
using System.Collections.Generic;

namespace H3_CopenhagenAirport_DBFirst
{
    public partial class Airport
    {
        public Airport()
        {
            ProuteDestinationNavigation = new HashSet<Proute>();
            ProuteOriginNavigation = new HashSet<Proute>();
        }

        public string Aiata { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Proute> ProuteDestinationNavigation { get; set; }
        public virtual ICollection<Proute> ProuteOriginNavigation { get; set; }
    }
}
