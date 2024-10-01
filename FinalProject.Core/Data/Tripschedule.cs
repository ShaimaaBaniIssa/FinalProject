using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Tripschedule
    {
        public Tripschedule()
        {
            Reservations = new HashSet<Reservation>();
        }

        public decimal Tripscheduleid { get; set; }
        public DateTime? Departuretime { get; set; }
        public DateTime? Arrivaltime { get; set; }
        public decimal? Tripid { get; set; }
        public decimal? Trainid { get; set; }

        public virtual Train? Train { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
