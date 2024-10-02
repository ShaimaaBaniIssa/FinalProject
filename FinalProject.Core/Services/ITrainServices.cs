using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface ITrainServices
    {
        List<Train> GetAllTrains();
        Train GetTrainById(int id);
        void CreateTrain(Train train);
        void UpdateTrain(Train train);
        void DeleteTrain(int id);
    }
}
