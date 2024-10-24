using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
    public class CreateReservationDto
    {
  
        public int tripId { get; set; }
        public int tripScheduleId { get; set; }

        public int customerId { get; set; }
        public DateTime reservationDate { get; set; }

        public List<Ticket> tickets { get; set; }
        public Bankcard bankcard { get; set; }
    }
}
