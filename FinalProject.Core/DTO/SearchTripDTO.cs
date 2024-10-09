using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
    public class SearchTripDTO
    {

        public int TripScheduleId { get; set; }
        public string? DepartureTime { get; set; }
        public string? ArrivalTime { get; set; }
        public int TripId { get; set; }
        public int TrainId { get; set; }
        public DateTime? TDate { get; set; }

    }
}
