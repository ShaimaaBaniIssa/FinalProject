using FinalProject.Core.Data;

namespace FinalProject.Core.Repository
{
    public interface ITripScheduleRepository
    {
        List<Tripschedule> GetAllTripSchedules();
        Tripschedule GetTripScheduleById(int id);
        void CreateTripSchedule(Tripschedule tripSchedule);
        void UpdateTripSchedule(Tripschedule tripSchedule);
        void DeleteTripSchedule(int id);
        Tripschedule CheckTripScheduleAvailability(int tripId, DateTime date, string hour);
        bool CheckTrainAvailabilty(int trainId, DateTime date, string hour);
    }
}
