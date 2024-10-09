using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
    public class AvailableTripScheduleDTO
    {
        public List<Seat> Seats { get; set; }
        public int TripScheduleId { get; set; }
    }
}
