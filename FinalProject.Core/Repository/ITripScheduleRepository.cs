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
        List<SearchTripDTO> SearchTrip(DateTime startDate, DateTime endDate);
        Tripschedule CheckTripScheduleAvailability(int tripId, DateTime date, string hour);
        bool CheckTrainAvailabilty(int trainId, DateTime date, string hour);
    }
}
