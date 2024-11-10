using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        int CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
        Task<List<Reservation>> GetReservationsWithCustomer();
        List<ReservationDto> GetReservationByCustId(int custId);
        List<Invoice> GetInvoice(int reservationId);
        List<ReservationDto> MonthlyAnnualReports(int? month, int year);
        List<MonthlyreportDTO> GetMonthlyReservationCount();

    }
}
