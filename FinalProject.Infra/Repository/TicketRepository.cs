using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public  class TicketRepository: ITicketRepository
    {
        private readonly IDbContext _dbContext;
        public TicketRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Ticket> GetAllTickets()
        {

            //query == reterive data from db 

            IEnumerable<Ticket> result = _dbContext.Connection.Query<Ticket>("Ticket_Package.GetAllTickets", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public Ticket GetTicketById(int id)

        {

            //dapper

            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_TicketId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Ticket>("Ticket_Package.GetTicketById", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
        public void CreateTicket(Ticket ticket)

        {

            var p = new DynamicParameters();

            p.Add("p_ReservationId", ticket.Reservationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_SeatId", ticket.Seatid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_FullName", ticket.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NationalId", ticket.Nationalid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DateOfBirth", ticket.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Gender", ticket.Gender, dbType: DbType.String, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Ticket_Package.CreateTicket", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateTicket(Ticket ticket)

        {


            var p = new DynamicParameters();
            p.Add("p_TicketId", ticket.Ticketid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_ReservationId", ticket.Reservationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_SeatId", ticket.Seatid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_FullName", ticket.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NationalId", ticket.Nationalid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DateOfBirth", ticket.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Gender", ticket.Gender, dbType: DbType.String, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Ticket_Package.UpdateTicket", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteTicket(int id)

        {

            var p = new DynamicParameters();

            p.Add("p_TicketId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Ticket_Package.DeleteTicket", p, commandType: CommandType.StoredProcedure);

        }
        public async Task<List<Ticket>> GetTicketsWithReservation()
        {
            var p = new DynamicParameters(); 
            var result = await _dbContext.Connection.QueryAsync<Ticket, Reservation, Ticket>
                ("Ticket_Package.GetTicketsWithReservations",
            (ticket, reservation) =>
            {
                
                ticket.Reservation = new Reservation
                {
                    Reservationid = reservation.Reservationid,  
                    Customerid = reservation.Customerid,       
                    Reservationdate = reservation.Reservationdate, 
                    Totalprice = reservation.Totalprice,       
                    Tripscheduleid = reservation.Tripscheduleid 
                };
                return ticket; 
            },
            splitOn: "Reservationid", 
            commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        
        public List<Ticket> GetTicketsByReservationId(int reservationId)
        {
            var p = new DynamicParameters();  
            p.Add("p_reservationId", reservationId, dbType: DbType.Int32, direction: ParameterDirection.Input); 

            var result = _dbContext.Connection.Query<Ticket>("Ticket_Package.GetTicketsByReservationId", p, commandType: CommandType.StoredProcedure); 

            return result.ToList(); 
        }
    }
}

