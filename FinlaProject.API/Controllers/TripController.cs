using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpGet]
        public List<Trip> GetAllTrips()
        {
             return _tripService.GetAllTrips(); 
        }
        [HttpGet]
        [Route("GetTripById/{id}")]
        public Trip GetTripById(int id)
        {
            return _tripService.GetTripById(id);
        }
        [HttpPost]
        [Route("CreateTrip")]
        public void CreateTrip(Trip trip)
        {
            _tripService.CreateTrip(trip);
        }
        [HttpPut]
        [Route("UpdateTrip")]
        public void UpdateTrip(Trip trip)
        {
            _tripService.UpdateTrip(trip);
        }
        [HttpDelete]
        [Route("DeleteTrip/{id}")]
        public void DeleteTrip(int id)
        {
            _tripService.DeleteTrip(id);
        }
        [HttpGet]
        [Route("GetTripsWithSchedules")]
        public Task<List<Trip>> GetTripsWithSchedules()
        {
            return _tripService.GetTripsWithSchedules();
        }
    }
}
