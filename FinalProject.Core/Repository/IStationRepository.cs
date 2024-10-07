using FinalProject.Core.Data;
using FinalProject.Core.DTO;

namespace FinalProject.Core.Repository
{
    public interface IStationRepository
    {
        List<Station> GetAllStations();
        Station GetStationById(int id);
        void CreateStation(Station station);
        void UpdateStation(Station station);
        void DeleteStation(int id);
        Task<List<Station>> GetStationsWithTrips();
        List<StationCountDTO> CountStation(StationCountDTO stationCountDTO);
    }
}
