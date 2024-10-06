﻿using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Utility;
using System;
using System.Collections.Generic;
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
        public void CreateReservation(Reservation reservation)
        {
            _reservationRepository.CreateReservation(reservation);
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
        public List<Reservation> GetReservationByCustId(int custId)
        {
            return _reservationRepository.GetReservationByCustId(custId);
        }
        public List<Invoice> GetInvoice(int reservationId)
        {
            return _reservationRepository.GetInvoice(reservationId);
        }
        public int CreateReservationAndTickets(int tripScheduleId, int customerId, DateTime reservationDate,
                                           List<int> seatIds, string fullName, string nationalId,
                                           DateTime dateOfBirth, string gender, decimal ticketPrice)
        {
            return _reservationRepository.CreateReservationAndTickets( tripScheduleId,  customerId,  reservationDate,
                                            seatIds,  fullName,  nationalId,
                                            dateOfBirth,  gender,  ticketPrice);
        }
    }
}

