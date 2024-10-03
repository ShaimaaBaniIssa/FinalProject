using FinalProject.Core.Data;

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
    }
}
