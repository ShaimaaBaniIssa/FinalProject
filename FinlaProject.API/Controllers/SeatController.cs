using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatServices _seatServices;
        public SeatController(ISeatServices seatServices)
        {
            _seatServices = seatServices;
        }

        [HttpGet]
        public List<Seat> GetAllSeats()
        {
            return _seatServices.GetAllSeats();
        }

        [HttpGet]
        [Route("GetSeatById/{id}")]
        public Seat GetSeatById(int id)
        {
            return _seatServices.GetSeatById(id);

        }

        [HttpPost]
        [Route("CreateSeat")]
        public void CreateSeat(Seat seat)
        {
            _seatServices.CreateSeat(seat);
        }


        [HttpPut]
        [Route("UpdateSeat")]
        public void UpdateSeat(Seat seat)
        {
            _seatServices.UpdateSeat(seat);

        }

        [HttpDelete]
        [Route("DeleteSeat/{id}")]
        public void DeleteSeat(int id)
        {
            _seatServices.DeleteSeat(id);
        }

        [HttpGet]
        [Route("GetTripScheduleSeats/{tripScheduleId}")]
        public List<Seat> GetTrainSeats(int tripScheduleId)
        {
            return _seatServices.GetTripScheduleSeats(tripScheduleId);

        }
        [HttpGet]
        [Route("GetSeatByTrainId/{trainid}")]
        public List<Seat> GetTripsByStationId(int trainid)
        {
            return _seatServices.GetSeatByTrainId(trainid);
        }

    }
}
