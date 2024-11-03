﻿using FinalProject.Core.Data;
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
        public TripScheduleController(ITripScheduleService tripScheduleService, ISeatServices seatServices, ITripService tripService)
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

            // validate the hour
            bool isValidDeparturetime = DateTime.TryParseExact(tripSchedule.Departuretime, "HH:mm",
                null, System.Globalization.DateTimeStyles.None,
                out DateTime departuretime);
            bool isValidArrivaltime = DateTime.TryParseExact(tripSchedule.Arrivaltime, "HH:mm",
                null, System.Globalization.DateTimeStyles.None,
               out DateTime arrivaltime);

            if (!isValidDeparturetime || !isValidArrivaltime)
            {
                return BadRequest("Hour must be in HH:mm format");
            }


            if (arrivaltime.CompareTo(departuretime) != 1)
                return BadRequest("Arrival time must be greater than Departure time"); ;

            // check first if the train is avaialble at the selected date
            bool isAvailable = _tripScheduleService.CheckTrainAvailabilty((int)tripSchedule.Trainid, tripSchedule.Tdate.Value, tripSchedule.Departuretime);
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
        [Route("SearchTrip")]
        public List<SearchTripDTO> SearchTrip(DateTime startDate, DateTime endDate)
        { 

            return _tripScheduleService.SearchTrip(startDate, endDate);
        }
        [HttpGet]
        [Route("CheckTripScheduleAvailability/{tripId}/{tripScheduleDate}")]
        public bool CheckTripScheduleAvailability(int tripId, DateTime tripScheduleDate)
        {

            // Get the string representation of the day of the week for the given date
            var dateName = tripScheduleDate.DayOfWeek.ToString();
            var trip = _tripService.GetTripById(tripId);
            bool availableDay = false;

            // Check each day of the week
            //using StringComparison.OrdinalIgnoreCase will help avoid issues with case sensitivity.
            if (trip.Sunday.HasValue && trip.Sunday.Value && dateName.Equals(DayOfWeek.Sunday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }
            else if (trip.Saturday.HasValue && trip.Saturday.Value && dateName.Equals(DayOfWeek.Saturday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }
            else if (trip.Monday.HasValue && trip.Monday.Value && dateName.Equals(DayOfWeek.Monday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }
            else if (trip.Tuesday.HasValue && trip.Tuesday.Value && dateName.Equals(DayOfWeek.Tuesday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }
            else if (trip.Wednesday.HasValue && trip.Wednesday.Value && dateName.Equals(DayOfWeek.Wednesday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }
            else if (trip.Thursday.HasValue && trip.Thursday.Value && dateName.Equals(DayOfWeek.Thursday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }
            else if (trip.Friday.HasValue && trip.Friday.Value && dateName.Equals(DayOfWeek.Friday.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                availableDay = true;
            }

          
            return availableDay;

        }
        [HttpGet]
        [Route("GetAvailableSeats/{tripScheduleId}")]
        public List<Seat> GetAvailableSeats(int tripScheduleId)
        {
            
            var result = _seatServices.GetTripScheduleSeats(tripScheduleId);
            return result.ToList();
           
        }
        [HttpGet]
        [Route("GetTripScheduleByTripId/{id}")]
        public List<Tripschedule> GetTripScheduleByTripId(int id)
        {
            return _tripScheduleService.GetTripScheduleByTripId(id);
        }
    }
}
