using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public void CreateTrip(Trip trip)
        {
            _tripService.CreateTrip(trip);
        }
        [HttpPut]
        [Route("UpdateTrip")]
        [CheckClaims("roleid", "21")]
        public void UpdateTrip(Trip trip)
        {
            _tripService.UpdateTrip(trip);
        }
        [HttpDelete]
        [Route("DeleteTrip/{id}")]
        [CheckClaims("roleid", "21")]
        public void DeleteTrip(int id)
        {
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
