using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            p.Add("p_DepartureTime", tripSchedule.Departuretime, DbType.DateTime, ParameterDirection.Input);
            p.Add("p_ArrivalTime", tripSchedule.Arrivaltime, DbType.DateTime, ParameterDirection.Input);
            p.Add("p_TripId", tripSchedule.Tripid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_TrainId", tripSchedule.Trainid, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("TripSchedule_Package.CreateTripSchedule", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTripSchedule(Tripschedule tripSchedule)
        {
            var p = new DynamicParameters();
            p.Add("p_TripScheduleId", tripSchedule.Tripscheduleid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_DepartureTime", tripSchedule.Departuretime, DbType.DateTime, ParameterDirection.Input);
            p.Add("p_ArrivalTime", tripSchedule.Arrivaltime, DbType.DateTime, ParameterDirection.Input);
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
        public List<SearchTripDTO> SearchTrip(DateTime tDate)
        {
            var p = new DynamicParameters();
            p.Add("p_TDate", tDate, DbType.DateTime, ParameterDirection.Input);
            var res = _dbContext.Connection.Query<SearchTripDTO>("SearchTripScheduleByDate", p, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }
    }
}
