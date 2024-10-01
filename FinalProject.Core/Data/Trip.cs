using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Trip
    {
        public Trip()
        {
            Tripschedules = new HashSet<Tripschedule>();
        }

        public decimal Tripid { get; set; }
        public decimal? Destlatitude { get; set; }
        public decimal? Destlongitude { get; set; }
        public decimal? Price { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public decimal? Stationid { get; set; }

        public virtual Station? Station { get; set; }
        public virtual ICollection<Tripschedule> Tripschedules { get; set; }
    }
}
