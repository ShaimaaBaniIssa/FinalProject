using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System.Data;

namespace FinalProject.Infra.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly IDbContext _dbContext;

        public StationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Station> GetAllStations()
        {
            IEnumerable<Station> result = _dbContext.Connection.Query<Station>("Station_Package.GetAllStations", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Station GetStationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_StationId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Station>("Station_Package.GetStationById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateStation(Station station)
        {
            var p = new DynamicParameters();
            p.Add("p_StationName", station.Stationname, DbType.String, ParameterDirection.Input);
            p.Add("p_Latitude", station.Latitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_Longitude", station.Longitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_ImagePath", station.Imagepath, DbType.String, ParameterDirection.Input);
            p.Add("p_Address", station.Address, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("Station_Package.CreateStation", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateStation(Station station)
        {
            var p = new DynamicParameters();
            p.Add("p_StationId", station.Stationid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StationName", station.Stationname, DbType.String, ParameterDirection.Input);
            p.Add("p_Latitude", station.Latitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_Longitude", station.Longitude, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_ImagePath", station.Imagepath, DbType.String, ParameterDirection.Input);
            p.Add("p_Address", station.Address, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("Station_Package.UpdateStation", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStation(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_StationId", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Station_Package.DeleteStation", p, commandType: CommandType.StoredProcedure);
        }
    }
}
