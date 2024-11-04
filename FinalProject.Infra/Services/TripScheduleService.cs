using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;

namespace FinalProject.Infra.Services
{
    public class TripScheduleService : ITripScheduleService
    {

        private readonly ITripScheduleRepository _tripScheduleRepository;
        public TripScheduleService(ITripScheduleRepository tripScheduleRepository)
        {
            _tripScheduleRepository = tripScheduleRepository;
        }
        public void CreateTripSchedule(Tripschedule tripSchedule)
        {
            _tripScheduleRepository.CreateTripSchedule(tripSchedule);
        }

        public void DeleteTripSchedule(int id)
        {
            _tripScheduleRepository.DeleteTripSchedule(id);
        }

        public List<Tripschedule> GetAllTripSchedules()
        {
            return _tripScheduleRepository.GetAllTripSchedules();   
        }

        public Tripschedule GetTripScheduleById(int id)
        {
            return _tripScheduleRepository.GetTripScheduleById(id);
        }

        public void UpdateTripSchedule(Tripschedule tripSchedule)
        {
            _tripScheduleRepository.UpdateTripSchedule(tripSchedule);
        }
        public List<SearchTripDTO> SearchTrip(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _tripScheduleRepository.SearchTrip(startDate, endDate);
        }
        public List<Tripschedule> CheckTripScheduleAvailability(int tripId, DateTime date)
        {
            return _tripScheduleRepository.CheckTripScheduleAvailability(tripId, date);
        }
        public bool CheckTrainAvailabilty(int trainId, DateTime date, string hour)
        {
            return _tripScheduleRepository.CheckTrainAvailabilty(trainId, date, hour);
        }
        public List<Tripschedule> GetTripScheduleByTripId(int tripId)
        {
            return _tripScheduleRepository.GetTripScheduleByTripId(tripId);
        }

    }
}
