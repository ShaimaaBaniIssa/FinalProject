using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        public decimal Seatid { get; set; }
        public string? Seatnumber { get; set; }
        public decimal? Trainid { get; set; }

        public virtual Train? Train { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
