using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripScheduleController : ControllerBase
    {
        private readonly ITripScheduleService _tripScheduleService;
        private readonly ISeatServices _seatServices;
        private readonly ITripService _tripService;
        public TripScheduleController(ITripScheduleService tripScheduleService,ISeatServices seatServices,ITripService tripService)
        {
            _tripScheduleService = tripScheduleService;
             _seatServices = seatServices;
            _tripService = tripService;
        }
        [HttpGet]
        public List<Tripschedule> GetAllTripSchedules()
        {
            return _tripScheduleService.GetAllTripSchedules();
        }
        [HttpGet]
        [Route("GetTripScheduleById/{id}")]
        public Tripschedule GetTripScheduleById(int id)
        {
            return _tripScheduleService.GetTripScheduleById(id);
        }
        [HttpPost]
        [Route("CreateTripSchedule")]
        public IActionResult CreateTripSchedule(Tripschedule tripSchedule)
        {
            // check first if the train is avaialble at the selected date
            bool isAvailable = _tripScheduleService.CheckTrainAvailabilty((int)tripSchedule.Trainid, tripSchedule.Tdate.Value);
            if (!isAvailable)
                return BadRequest("Train is not available ");

            _tripScheduleService.CreateTripSchedule(tripSchedule);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateTripSchedule")]
        public void UpdateTripSchedule(Tripschedule tripSchedule)
        {
            _tripScheduleService.UpdateTripSchedule(tripSchedule);
        }
        [HttpDelete]
        [Route("DeleteTripSchedule/{id}")]
        public void DeleteTripSchedule(int id)
        {
            _tripScheduleService.DeleteTripSchedule(id);
        }
        [HttpGet]
        [Route("CheckTripScheduleAvailability")]
        public AvailableTripScheduleDTO CheckTripScheduleAvailability(int tripId, DateTime reservationDate, string hour)
        {
            // check tripschedule 
            // tripid, date, time
            // available (train 
            // check if the reservation date 
            // List<seat>


            // 1. match trip days
            var dateName = reservationDate.DayOfWeek.ToString();
            var trip = _tripService.GetTripById(tripId);
            bool availableDay = false;
            // check day
            if (trip.Saturday.Value && dateName.Equals(DayOfWeek.Saturday))
                availableDay = true;
            else if (trip.Sunday.Value && dateName.Equals(DayOfWeek.Sunday))
                availableDay = true;
            else if (trip.Monday.Value && dateName.Equals(DayOfWeek.Monday))
                availableDay = true;
            else if (trip.Tuesday.Value && dateName.Equals(DayOfWeek.Tuesday))
                availableDay = true;
            else if (trip.Wednesday.Value && dateName.Equals(DayOfWeek.Wednesday))
                availableDay = true;
            else if (trip.Thursday.Value && dateName.Equals(DayOfWeek.Thursday))
                availableDay = true;
            else if (trip.Friday.Value && dateName.Equals(DayOfWeek.Friday))
                availableDay = true;


            // check date, time , tripid
            var tripschedule = _tripScheduleService.CheckTripScheduleAvailability(tripId, reservationDate, hour);
            var result = _seatServices.GetTripScheduleSeats((int)tripschedule.Tripscheduleid);
            return new AvailableTripScheduleDTO
            {
                Seats = result.ToList(),
                TripScheduleId = (int)tripschedule.Tripscheduleid
            };

        }
    }
}
