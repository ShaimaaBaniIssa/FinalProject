using Dapper;
using FinalProject.Core.Common;
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
using static QuestPDF.Helpers.Colors;

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
        public int CreateReservation(Reservation reservation)

        {
            var p = new DynamicParameters();

            p.Add("p_tripScheduleId", reservation.Tripscheduleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_customerId", reservation.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_reservationDate", reservation.Reservationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_totalPrice", reservation.Totalprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_r_date", reservation.RDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_ReservationId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            

            _dbContext.Connection.Execute("Reservation_Package.CreateReservation", p, commandType: CommandType.StoredProcedure);
            int reservationId = p.Get<int>("p_ReservationId");

            return reservationId;
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
        public List<ReservationDto> GetReservationByCustId(int custId)

        {

            var p = new DynamicParameters(); 

            p.Add("p_customerId", custId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<ReservationDto>("Reservation_Package.GetReservationByCustId", p, commandType: CommandType.StoredProcedure);

            return result.ToList() ;    

        }

        public List<Invoice> GetInvoice(int reservationId)
        {
            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_reservationId", reservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Invoice>("Reservation_Package.GetReservationDetails", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<ReservationDto> MonthlyAnnualReports(int? month, int year)
        {
            
            if (month == 0)
            {
                month = null;
            }

            
            var p = new DynamicParameters();
            p.Add("p_month", month, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_year", year, dbType: DbType.Int32, direction: ParameterDirection.Input);

           
            var result = _dbContext.Connection.Query<ReservationDto>("Report.MonthlyAnnualReports", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<MonthlyreportDTO> GetMonthlyReservationCount()
        {
            var result = _dbContext.Connection.Query<MonthlyreportDTO>("Report.GetMonthlyReservationCount",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}


