using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public class TrainRepository: ITrainRepository
    {
        private readonly IDbContext _dbContext;
        public TrainRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Train> GetAllTrains() {
            IEnumerable<Train> result = _dbContext.Connection.Query<Train>("Train_Package.GetAllTrains", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Train GetTrainById(int id) {
            var p = new DynamicParameters();
            p.Add("p_TrainId", id, dbType: DbType.Int32, direction:ParameterDirection.Input);
            var result=_dbContext.Connection.Query<Train>("Train_Package.GetTrainById", p,commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }
        public void CreateTrain(Train train)
        {
            bool availabilityValue = train.Availability ?? false;
            var p = new DynamicParameters();
            p.Add("p_TrainName", train.Trainname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Availability", availabilityValue ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_NumOfSeats", train.Numofseats , dbType: DbType.Int32, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Train_Package.CreateTrain", p, commandType: CommandType.StoredProcedure);
          

        }
        public void UpdateTrain(Train train)
        {
            bool availabilityValue = train.Availability ?? false;

            var p = new DynamicParameters();
            p.Add("p_TrainId", train.Trainid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TrainName", train.Trainname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Availability", availabilityValue ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_NumOfSeats", train.Numofseats, dbType: DbType.Int32, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Train_Package.UpdateTrain", p, commandType: CommandType.StoredProcedure);


        }

        public void  DeleteTrain(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_TrainId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Train_Package.DeleteTrain", p, commandType: CommandType.StoredProcedure);
            

        }
    }
}
