using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IBankCardService _bankCardService;
        public ReservationService(IReservationRepository reservationRepository
            , IBankCardService bankCardService)
        {
            _reservationRepository = reservationRepository;
            _bankCardService = bankCardService;
        }
        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }
        public Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetReservationById(id);
        }
        public int CreateReservation(Reservation reservation)
        {
            return _reservationRepository.CreateReservation(reservation);
        }
        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.UpdateReservation(reservation);
        }
        public void DeleteReservation(int id)
        {
            _reservationRepository.DeleteReservation(id);
        }
        public Task<List<Reservation>> GetReservationsWithCustomer()
        {
            return _reservationRepository.GetReservationsWithCustomer();
        }
        public List<ReservationDto> GetReservationByCustId(int custId)
        {
            return _reservationRepository.GetReservationByCustId(custId);
        }
        public List<Invoice> GetInvoice(int reservationId)
        {
            return _reservationRepository.GetInvoice(reservationId);
        }
        public List<MonthlyAnnualDTO> MonthlyAnnualReports(int? month, int year)
        {

          return _reservationRepository.MonthlyAnnualReports(month, year);
        }

    }
}

