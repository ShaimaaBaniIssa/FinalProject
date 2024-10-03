using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;

namespace FinalProject.Infra.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public void CreateTrip(Trip trip)
        {
            _tripRepository.CreateTrip(trip);
        }

        public void DeleteTrip(int id)
        {
            _tripRepository.DeleteTrip(id);
        }

        public List<Trip> GetAllTrips()
        {
            return _tripRepository.GetAllTrips();   
        }

        public Trip GetTripById(int id)
        {
            return _tripRepository.GetTripById(id);
        }

        public Task<List<Trip>> GetTripsWithSchedules()
        {
            return _tripRepository.GetTripsWithSchedules();
        }

        public void UpdateTrip(Trip trip)
        {
            _tripRepository.UpdateTrip(trip);
        }
    }
}
