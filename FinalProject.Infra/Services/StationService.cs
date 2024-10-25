using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System.Data;

namespace FinalProject.Infra.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        public void CreateStation(Station station)
        {
            _stationRepository.CreateStation(station);
        }

        public void DeleteStation(int id)
        {
            _stationRepository.DeleteStation(id);
        }

        public List<Station> GetAllStations()
        {
            return _stationRepository.GetAllStations();
        }

        public Station GetStationById(int id)
        {
            return _stationRepository.GetStationById(id);
        }

        public Task<List<Station>> GetStationsWithTrips()
        {
            return _stationRepository.GetStationsWithTrips();
        }

        public void UpdateStation(Station station)
        {
           _stationRepository.UpdateStation(station);
        }
        public List<SearchStationDTO> SearchStation(string staionName)
        {
            return _stationRepository.SearchStation(staionName);
        }
        public int StationCount()
        {
            return _stationRepository.StationCount();
        }
    }
}
