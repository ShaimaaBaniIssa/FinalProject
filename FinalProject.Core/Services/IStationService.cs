

using FinalProject.Core.Data;

namespace FinalProject.Core.Services
{
    public interface IStationService
    {
        List<Station> GetAllStations();
        Station GetStationById(int id);
        void CreateStation(Station station);
        void UpdateStation(Station station);
        void DeleteStation(int id);
    }
}
