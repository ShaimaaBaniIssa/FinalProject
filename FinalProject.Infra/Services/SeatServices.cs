using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
