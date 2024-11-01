using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainServices _trainServices;
        public TrainController(ITrainServices trainServices)
        {
            _trainServices = trainServices;
          
        }
        [HttpGet]
        public List<Train> GetAllTrains()
        {
            return _trainServices.GetAllTrains();

        }

        [HttpGet]
        [Route("GetTrainById/{id}")]
        public Train GetTrainById(int id)
        {
            return _trainServices.GetTrainById(id);

        }
        [HttpPost]
        [Route("CreateTrain")]
        public IActionResult CreateTrain(Train train)
        {
            try
            {
                _trainServices.CreateTrain(train);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error occured while creating the train");
            }

        }


        [HttpPut]
        [Route("UpdateTrain")]
        public IActionResult UpdateTrain(Train train)
        {
            try
            {
                _trainServices.UpdateTrain(train);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("cannot update this train");
            }

        }

        [HttpDelete]
        [Route("DeleteTrain/{id}")]
        public IActionResult DeleteTrain(int id)
        {
            try
            {
                _trainServices.DeleteTrain(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("cannot delete this train");
            }
        }
    }
}
