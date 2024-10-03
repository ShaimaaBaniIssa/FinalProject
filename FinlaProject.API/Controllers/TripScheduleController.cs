using FinalProject.Core.Data;
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
        public TripScheduleController(ITripScheduleService tripScheduleService)
        {
            _tripScheduleService = tripScheduleService;
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
        public void CreateTripSchedule(Tripschedule tripSchedule)
        {
            _tripScheduleService.CreateTripSchedule(tripSchedule);
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
    }
}
