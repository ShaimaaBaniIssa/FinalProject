using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;

        }
        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return _reservationService.GetAllReservations();
        }
        [HttpGet]
        [Route("GetReservationById/{id}")]
        public Reservation GetReservationById(int id)
        {
            return _reservationService.GetReservationById(id);
        }
        [HttpPost]
        [Route("CreateReservation")]
        public void CreateReservation(Reservation reservation)
        {
            _reservationService.CreateReservation(reservation);
        }
        [HttpPut]

        [Route("UpdateReservation")]
        public void UpdateReservation(Reservation reservation)
        {
            _reservationService.UpdateReservation(reservation);
        }
        [HttpDelete]
        [Route("DeleteReservation/{id}")]
        public void DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
        }
    }



}
