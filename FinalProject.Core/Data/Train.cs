using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Train
    {
        public Train()
        {
            Seats = new HashSet<Seat>();
            Tripschedules = new HashSet<Tripschedule>();
        }

        public decimal Trainid { get; set; }
        public string? Trainname { get; set; }
        public bool? Availability { get; set; }
        public decimal? Numofseats { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Tripschedule> Tripschedules { get; set; }
    }
}
