using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
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
        [Route("UploadImage")]
        [HttpPost]
        public Station UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Station station = new Station();
            station.Imagepath = fileName;
            return station;
        }
        [HttpGet]
        [Route("GetStationsWithTrips")]
        public Task<List<Station>> GetStationsWithTrips()
        {
            return _stationService.GetStationsWithTrips();
        }


        [HttpGet]
        [Route("SearchStation")]
        public List<SearchStationDTO> SearchStation(string staionName)
        {
            return _stationService.SearchStation(staionName);
        }
        [HttpGet]
        [Route("CountCustomer")]
        public List<StationCountDTO> StationCount(StationCountDTO stationCountDTO)
        {
            return _stationService.StationCount(stationCountDTO);
        }
    }
}
