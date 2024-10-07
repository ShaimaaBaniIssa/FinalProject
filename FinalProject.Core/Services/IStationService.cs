

using FinalProject.Core.Data;
using FinalProject.Core.DTO;

namespace FinalProject.Core.Services
{
    public interface IStationService
    {
        List<Station> GetAllStations();
        Station GetStationById(int id);
        void CreateStation(Station station);
        void UpdateStation(Station station);
        void DeleteStation(int id);
        Task<List<Station>> GetStationsWithTrips();
        List<SearchStationDTO> SearchStation(string staionName);
        List<StationCountDTO> StationCount(StationCountDTO stationCountDTO);
    }
}
