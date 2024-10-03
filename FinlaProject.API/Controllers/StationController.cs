using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        [HttpGet]
        public List<Station> GetAllStations()
        {
            return _stationService.GetAllStations();
        }
        [HttpGet]
        [Route("GetStationById/{id}")]
        public Station GetStationById(int id)
        {
            return _stationService.GetStationById(id);
        }
        [HttpPost]
        [Route("CreateStation")]
        public void CreateStation(Station station)
        {
            _stationService.CreateStation(station);
        }
        [HttpPut]
        [Route("CreateStation")]
        public void UpdateStation(Station station)
        {
            _stationService.UpdateStation(station);
        }
        [HttpDelete]
        [Route("DeleteStation/{id}")]
        public void DeleteStation(int id)
        {
            _stationService?.DeleteStation(id); 
        }
    }
}
