using FinalProject.Core.Data;

namespace FinalProject.Core.Repository
{
    public interface ITripRepository
    {
        List<Trip> GetAllTrips();
        Trip GetTripById(int id);
        void CreateTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int id);
        Task<List<Trip>> GetTripsWithSchedules();

    }
}
