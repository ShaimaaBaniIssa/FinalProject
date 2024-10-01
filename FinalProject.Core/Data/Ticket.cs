using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Ticket
    {
        public decimal Ticketid { get; set; }
        public decimal? Reservationid { get; set; }
        public decimal? Seatid { get; set; }
        public string? Fullname { get; set; }
        public string? Nationalid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Gender { get; set; }

        public virtual Reservation? Reservation { get; set; }
        public virtual Seat? Seat { get; set; }
    }
}
