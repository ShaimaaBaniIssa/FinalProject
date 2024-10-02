using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface ISeatRepository
    {
        List<Seat> GetAllSeats();
        Seat GetSeatById(int id);
        void CreateSeat(Seat seat);
        void UpdateSeat(Seat seat);
        void DeleteSeat(int id);
    }
}
