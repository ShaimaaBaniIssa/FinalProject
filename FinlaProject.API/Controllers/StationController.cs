using FinalProject.Core.Data;
using FinalProject.Core.DTO;
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

    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IConfiguration _configuration;

        public StationController(IStationService stationService, IConfiguration configuration)
        {
            _stationService = stationService;
            _configuration = configuration;
        }
        [HttpGet]
        [AllowAnonymous]
        public List<Station> GetAllStations()
        {
            return _stationService.GetAllStations();
        }
        [HttpGet]
        [Route("GetStationById/{id}")]
        [AllowAnonymous]

        public Station GetStationById(int id)
        {
            return _stationService.GetStationById(id);
        }
        [HttpPost]
        [Route("CreateStation")]
        [CheckClaims("roleid", "21")]

        public ActionResult CreateStation(Station station)
        {
            try
            {
                _stationService.CreateStation(station);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();

            }
        }
        [HttpPut]
        [Route("UpdateStation")]
        [CheckClaims("roleid", "21")]
        public ActionResult UpdateStation(Station station)
        {
            try
            {
                _stationService.UpdateStation(station);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();

            }
        }
        [HttpDelete]
        [Route("DeleteStation/{id}")]
        [CheckClaims("roleid", "21")]
        public ActionResult DeleteStation(int id)
        {
            try
            {
                _stationService?.DeleteStation(id);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();            
            }
        }
        [Route("UploadImage")]
        [HttpPost]
        [CheckClaims("roleid", "21")]
        public Station UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var imageFolderPath = _configuration["ImageFolderPath"];
            var fullPath = Path.Combine(imageFolderPath, fileName);
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
        [AllowAnonymous]
        public Task<List<Station>> GetStationsWithTrips()
        {
            return _stationService.GetStationsWithTrips();
        }


        [HttpGet]
        [Route("SearchStation/{staionName}")]
        [AllowAnonymous]
        public List<SearchStationDTO> SearchStation(string staionName)
        {
            return _stationService.SearchStation(staionName);
        }
        [HttpGet]
        [Route("StationCount")]
        [CheckClaims("roleid", "21")]
        public int StationCount()
        {
            return _stationService.StationCount();
        }
    }
}
