using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;

namespace FinalProject.Infra.Services
{
    public class SeatServices: ISeatServices
    {
        private readonly ISeatRepository _seatRepository;
        public SeatServices(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public List<Seat> GetAllSeats()
        {
            return _seatRepository.GetAllSeats();
        }
        public Seat GetSeatById(int id)
        {
           return _seatRepository.GetSeatById(id);

        }
        public void CreateSeat(Seat seat)
        {
            _seatRepository.CreateSeat(seat);
        }
        public void UpdateSeat(Seat seat)
        {
            _seatRepository.UpdateSeat(seat);

        }

        public void DeleteSeat(int id)
        {
            _seatRepository.DeleteSeat(id);
        }
        public List<Seat> GetTripScheduleSeats(int tripScheduleId)
        {
            return _seatRepository.GetTripScheduleSeats(tripScheduleId);
        }
        public void ReserveSeat(int seatId, int tripScheduleId)
        {
            _seatRepository.ReserveSeat(seatId, tripScheduleId);
        }
        public void RemoveReservedSeat(int seatId, int tripScheduleId)
        {
            _seatRepository.RemoveReservedSeat(seatId, tripScheduleId);
        }
        public List<Seat> GetSeatByTrainId(int trainid)
        {
            return _seatRepository.GetSeatByTrainId(trainid);
        }
    }
}
