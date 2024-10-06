using FinalProject.Core.Data;
using FinalProject.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
        Task<List<Reservation>> GetReservationsWithCustomer();
        List<Reservation> GetReservationByCustId(int custId);
        Invoice GetInvoice(int reservationId);
        void CreateReservationAndTickets(int tripScheduleId, int customerId, DateTime reservationDate,
                                           List<int> seatIds, string fullName, string nationalId,
                                           DateTime dateOfBirth, string gender, decimal ticketPrice);

    }
}
