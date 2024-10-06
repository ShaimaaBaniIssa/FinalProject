using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public class ReservationRepository: IReservationRepository
    
    {
        private readonly IDbContext _dbContext;
        public ReservationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Reservation> GetAllReservations()
        {

            //query == reterive data from db 

            IEnumerable<Reservation> result = _dbContext.Connection.Query<Reservation>("Reservation_Package.GetAllReservations", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public Reservation GetReservationById(int id)

        {

            //dapper

            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_reservationId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Reservation>("Reservation_Package.GetReservationById", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
        public void CreateReservation(Reservation reservation)

        {

            var p = new DynamicParameters();

            p.Add("p_tripScheduleId", reservation.Tripscheduleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_customerId", reservation.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_reservationDate", reservation.Reservationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_totalPrice", reservation.Totalprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_r_date", reservation.RDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);




            _dbContext.Connection.Execute("Reservation_Package.CreateReservation", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateReservation(Reservation reservation)

        {


            var p = new DynamicParameters();
            p.Add("p_reservationId", reservation.Reservationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_tripScheduleId", reservation.Tripscheduleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_customerId", reservation.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_reservationDate", reservation.Reservationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_totalPrice", reservation.Totalprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_r_date", reservation.RDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);




            _dbContext.Connection.Execute("Reservation_Package.UpdateReservation", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteReservation(int id)

        {

            var p = new DynamicParameters();

            p.Add("p_reservationId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Reservation_Package.DeleteReservation", p, commandType: CommandType.StoredProcedure);

        }
        public async Task<List<Reservation>> GetReservationsWithCustomer()
        {
            var p = new DynamicParameters();
            var result = await _dbContext.Connection.QueryAsync<Reservation, Customer, Reservation>
                ("Reservation_Package.GetReservationsWithCustomer",
            (reservation, customer) =>
            {
                reservation.Customer = new Customer
                {
                    Customerid = customer.Customerid,
                    Email = customer.Email,
                    Fname = customer.Fname,
                    Latitude = customer.Latitude,
                    Longitude = customer.Longitude,
                    Lname = customer.Lname,
                    Phonenumber = customer.Phonenumber
                };
                return reservation;
            },
            splitOn: "Customerid",
            commandType: CommandType.StoredProcedure

            );
            
            return result.ToList();
        }
        public List<Reservation> GetReservationByCustId(int custId)

        {

            var p = new DynamicParameters(); 

            p.Add("p_customerId", custId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Reservation>("Reservation_Package.GetReservationByCustId", p, commandType: CommandType.StoredProcedure);

            return result.ToList() ;    

        }

        public Invoice GetInvoice(int reservationId)
        {
            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_reservationId", reservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Invoice>("Reservation_Package.GetReservationDetails", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }
        public void CreateReservationAndTickets(int tripScheduleId, int customerId, DateTime reservationDate,
                                           List<int> seatIds, string fullName, string nationalId,
                                           DateTime dateOfBirth, string gender, decimal ticketPrice)
        {
            decimal totalPrice = ticketPrice * seatIds.Count;

            var pReservation = new DynamicParameters();
            pReservation.Add("p_tripScheduleId", tripScheduleId, DbType.Int32, ParameterDirection.Input);
            pReservation.Add("p_customerId", customerId, DbType.Int32, ParameterDirection.Input);
            pReservation.Add("p_reservationDate", reservationDate, DbType.Date, ParameterDirection.Input);
            pReservation.Add("p_totalPrice", totalPrice, DbType.Decimal, ParameterDirection.Input);
            pReservation.Add("p_r_date", DateTime.Now, DbType.Date, ParameterDirection.Input);
            pReservation.Add("p_ReservationId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.Execute("Reservation_Package.CreateReservation", pReservation, commandType: CommandType.StoredProcedure);

            int reservationId = pReservation.Get<int>("p_ReservationId");

            foreach (var seatId in seatIds)
            {
                var pTicket = new DynamicParameters();
                pTicket.Add("p_ReservationId", reservationId, DbType.Int32, ParameterDirection.Input);
                pTicket.Add("p_SeatId", seatId, DbType.Int32, ParameterDirection.Input);
                pTicket.Add("p_FullName", fullName, DbType.String, ParameterDirection.Input);
                pTicket.Add("p_NationalId", nationalId, DbType.String, ParameterDirection.Input);
                pTicket.Add("p_DateOfBirth", dateOfBirth, DbType.Date, ParameterDirection.Input);
                pTicket.Add("p_Gender", gender, DbType.String, ParameterDirection.Input);

                _dbContext.Connection.Execute("Ticket_Package.CreateTicket", pTicket, commandType: CommandType.StoredProcedure);

                var pSeat = new DynamicParameters();
                pSeat.Add("p_seatId", seatId, DbType.Int32, ParameterDirection.Input);
                pSeat.Add("p_availability", 0, DbType.Int32, ParameterDirection.Input);

                _dbContext.Connection.Execute("Seat_Package.UpdateSeatAvailability", pSeat, commandType: CommandType.StoredProcedure);
            }
        }
    

  
    }

}


