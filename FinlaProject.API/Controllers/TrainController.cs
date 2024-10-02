using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public void CreateTrain(Train train)
        {

            _trainServices.CreateTrain(train);

        }


        [HttpPut]
        [Route("UpdateTrain")]
        public void UpdateTrain(Train train)
        {
            _trainServices.UpdateTrain(train);

        }

        [HttpDelete]
        [Route("DeleteTrain/{id}")]
        public void DeleteTrain(int id)
        {
            _trainServices.DeleteTrain(id);

        }
    }
}
