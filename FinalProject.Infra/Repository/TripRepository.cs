using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System.Data;

namespace FinalProject.Infra.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly IDbContext _dbContext;

        public TripRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Trip> GetAllTrips()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("Trip_Package.GetAllTrips", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Trip GetTripById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_TripId", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Trip>("Trip_Package.GetTripById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateTrip(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("p_DestLatitude", trip.Destlatitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_DestLongitude", trip.Destlongitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_Price", trip.Price, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_Sunday", trip.Sunday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Monday", trip.Monday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Tuesday", trip.Tuesday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Wednesday", trip.Wednesday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Thursday", trip.Thursday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Friday", trip.Friday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Saturday", trip.Saturday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StationId", trip.Stationid, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Trip_Package.CreateTrip", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTrip(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("p_TripId", trip.Tripid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_DestLatitude", trip.Destlatitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_DestLongitude", trip.Destlongitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_Price", trip.Price, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_Sunday", trip.Sunday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Monday", trip.Monday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Tuesday", trip.Tuesday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Wednesday", trip.Wednesday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Thursday", trip.Thursday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Friday", trip.Friday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Saturday", trip.Saturday, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StationId", trip.Stationid, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Trip_Package.UpdateTrip", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTrip(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_TripId", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Trip_Package.DeleteTrip", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Trip>> GetTripsWithSchedules()
        {
            var result = await _dbContext.Connection.QueryAsync<Trip, Tripschedule, Trip>("Trip_Package.GetTripsWithSchedules",
            (Trip, tripSchedule) =>
            {
                Trip.Tripschedules.Add(new Tripschedule
                {
                    Tripscheduleid = tripSchedule.Tripscheduleid,
                    Arrivaltime = tripSchedule.Arrivaltime,
                    Departuretime = tripSchedule.Departuretime,
                    Trainid = tripSchedule.Trainid

                });
                return Trip;
            },
            splitOn: "Tripscheduleid",
            commandType: CommandType.StoredProcedure

            );
            var results = result.GroupBy(p => p.Stationid).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Tripschedules = g.Select(p => p.Tripschedules.Single()).ToList();
                return groupedPost;
            });
            return results.ToList();

        }

    }
}
