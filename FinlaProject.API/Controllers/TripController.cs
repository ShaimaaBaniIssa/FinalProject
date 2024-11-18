using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpGet]
        [AllowAnonymous]
        public List<Trip> GetAllTrips()
        {
             return _tripService.GetAllTrips(); 
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("GetTripById/{id}")]
       
        public Trip GetTripById(int id)
        {
            return _tripService.GetTripById(id);
        }
        [HttpPost]
        [Route("CreateTrip")]
        [CheckClaims("roleid", "21")]
        public IActionResult CreateTrip(Trip trip)
        {
            try
            {
                _tripService.CreateTrip(trip);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error occured while creating the train");
            }

        }
        [HttpPut]
        [Route("UpdateTrip")]
        [CheckClaims("roleid", "21")]
        public IActionResult UpdateTrip(Trip trip)
        {
            try
            {
                _tripService.UpdateTrip(trip);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error occured while updating the train");
            }
        }
        [HttpDelete]
        [Route("DeleteTrip/{id}")]
        [CheckClaims("roleid", "21")]
        public IActionResult DeleteTrip(int id)
        {
            try
            {
                _tripService.DeleteTrip(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error occured while deleting the train");
            }
            _tripService.DeleteTrip(id);
        }
        [HttpGet]
        [Route("GetTripsWithSchedules")]
        [CheckClaims("roleid", "21")]
        public Task<List<Trip>> GetTripsWithSchedules()
        {
            return _tripService.GetTripsWithSchedules();
        }
        [HttpGet]
        [Route("GetTripsByStationId/{stationId}")]
        [AllowAnonymous]
        public List<Trip> GetTripsByStationId(int stationId)
        {
            return _tripService.GetTripsByStationId(stationId);
        }
    }
}
