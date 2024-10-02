using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class TrainServices: ITrainServices
    {
        private readonly ITrainRepository _trainRepository;
        public TrainServices(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
         
        }

        public List<Train> GetAllTrains()
        {
            return _trainRepository.GetAllTrains();
            
        }
        public Train GetTrainById(int id)
        {
           return _trainRepository.GetTrainById(id);

        }
        public void CreateTrain(Train train)
        {

            _trainRepository.CreateTrain(train);

        }
        public void UpdateTrain(Train train)
        {
            _trainRepository.UpdateTrain(train);

        }

        public void DeleteTrain(int id)
        {
            _trainRepository.DeleteTrain(id);

        }
    }
}
