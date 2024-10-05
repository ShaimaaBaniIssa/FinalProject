using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
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


    }




}

