

namespace FinalProject.Core.DTO
{
    public class ReservationDto
    {
        public string? Stationname { get; set; }

        public string? Destaddress { get; set; }
        public decimal? Totalprice { get; set; }
        public DateTime? Reservationdate { get; set; }
        public DateTime? RDate { get; set; }
        public string? Departuretime { get; set; }
        public string? Arrivaltime { get; set; }
        public decimal Reservationid { get; set; }


    }
}
