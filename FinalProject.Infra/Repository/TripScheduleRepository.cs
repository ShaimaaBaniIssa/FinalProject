using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static QuestPDF.Helpers.Colors;

namespace FinalProject.Infra.Repository
{
    public class TripScheduleRepository : ITripScheduleRepository
    {
        private readonly IDbContext _dbContext;

        public TripScheduleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Tripschedule> GetAllTripSchedules()
        {
            IEnumerable<Tripschedule> result = _dbContext.Connection.Query<Tripschedule>("TripSchedule_Package.GetAllTripSchedules", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Tripschedule GetTripScheduleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_TripScheduleId", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Tripschedule>("TripSchedule_Package.GetTripScheduleById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateTripSchedule(Tripschedule tripSchedule)
        {
            var p = new DynamicParameters();
            p.Add("p_DepartureTime", tripSchedule.Departuretime, DbType.String, ParameterDirection.Input);
            p.Add("p_ArrivalTime", tripSchedule.Arrivaltime, DbType.String, ParameterDirection.Input);
            p.Add("p_TripId", tripSchedule.Tripid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_TrainId", tripSchedule.Trainid, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("TripSchedule_Package.CreateTripSchedule", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTripSchedule(Tripschedule tripSchedule)
        {
            var p = new DynamicParameters();
            p.Add("p_TripScheduleId", tripSchedule.Tripscheduleid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_DepartureTime", tripSchedule.Departuretime, DbType.String, ParameterDirection.Input);
            p.Add("p_ArrivalTime", tripSchedule.Arrivaltime, DbType.String, ParameterDirection.Input);
            p.Add("p_TripId", tripSchedule.Tripid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_TrainId", tripSchedule.Trainid, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("TripSchedule_Package.UpdateTripSchedule", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTripSchedule(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_TripScheduleId", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("TripSchedule_Package.DeleteTripSchedule", p, commandType: CommandType.StoredProcedure);
        }
        public Tripschedule CheckTripScheduleAvailability(int tripId,DateTime date ,string hour)
        {
            var p = new DynamicParameters();
            p.Add("p_tripid", tripId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_date", date, DbType.DateTime, ParameterDirection.Input);
            p.Add("p_time", hour, DbType.String, ParameterDirection.Input);


            var result = _dbContext.Connection.Query<Tripschedule>("TripSchedule_Package.CheckTripScheduleAvailability", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public bool CheckTrainAvailabilty(int trainId, DateTime date,string hour)
        {

            var p = new DynamicParameters();
            p.Add("p_date", date, DbType.DateTime, ParameterDirection.Input);
            p.Add("p_trainId", trainId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_hour", hour, DbType.String, ParameterDirection.Input);

            p.Add("p_count",dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.Execute("TripSchedule_Package.CheckTrainAvailabilty", p, commandType: CommandType.StoredProcedure);
            int count = p.Get<int>("p_count");

            
            return count == 0 ? true : false;
        }
    }
}
