using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;

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

        public void UpdateStation(Station station)
        {
           _stationRepository.UpdateStation(station);
        }
    }
}
