using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
   public class MonthlyAnnualDTO
    {
        public int NumUsers { get; set; }
    
        [JsonIgnore]  // Ignore this in the response
        public DateTime reservationDatee { get; set; }

        // Return a string without time
        public string ReservationDate => reservationDatee.ToString("yyyy-MM-dd");
    }
}
