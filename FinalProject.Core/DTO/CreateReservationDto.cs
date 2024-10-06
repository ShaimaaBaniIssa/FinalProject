using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
    public class CreateReservationDto
    {
        public int TripScheduleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReservationDate { get; set; }
        public List<int> SeatIds { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
