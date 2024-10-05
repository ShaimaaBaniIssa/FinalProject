using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Core.Data
{
    public partial class Reservation
    {
        public Reservation()
        {
            Tickets = new HashSet<Ticket>();
        }

        public decimal Reservationid { get; set; }
        public decimal? Tripscheduleid { get; set; }
        public decimal? Customerid { get; set; }
        public DateTime? Reservationdate { get; set; }
        public decimal? Totalprice { get; set; }
        public DateTime? RDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Tripschedule? Tripschedule { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
