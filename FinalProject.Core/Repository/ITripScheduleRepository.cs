using FinalProject.Core.Data;
using FinalProject.Core.DTO;

namespace FinalProject.Core.Repository
{
    public interface ITripScheduleRepository
    {
        List<Tripschedule> GetAllTripSchedules();
        Tripschedule GetTripScheduleById(int id);
        void CreateTripSchedule(Tripschedule tripSchedule);
        void UpdateTripSchedule(Tripschedule tripSchedule);
        void DeleteTripSchedule(int id);
        List<SearchTripDTO> SearchTrip(DateTime? startDate = null, DateTime? endDate = null);
        List<Tripschedule> CheckTripScheduleAvailability(int tripId, DateTime date);
        bool CheckTrainAvailabilty(int trainId, DateTime date, string hour);
        List<Tripschedule> GetTripScheduleByTripId(int tripId);
    }
}
