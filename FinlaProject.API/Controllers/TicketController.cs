using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        [CheckClaims("roleid", "21")]

        public List<Ticket> GetAllTickets()
        {
            return _ticketService.GetAllTickets();
        }
        [HttpGet]
        [CheckClaims("roleid", "21")]

        [Route("GetTicketById/{id}")]
        public Ticket GetTicketById(int id)
        {
            return _ticketService.GetTicketById(id);
        }
        [HttpPost]
        [Route("CreateTicket")]
        [CheckClaims("roleid", "1")]
     
        public void CreateTicket(Ticket ticket)
        {
            _ticketService.CreateTicket(ticket);
        }
        [HttpPut]

        [Route("UpdateTicket")]
        [CheckClaims("roleid", "21")]

        public void UpdateTicket(Ticket ticket)
        {
            _ticketService.UpdateTicket(ticket);
        }
        [HttpDelete]
        [Route("DeleteTicket/{id}")]
        [CheckClaims("roleid", "21")]

        public void DeleteTicket(int id)
        {
            _ticketService.DeleteTicket(id);
        }
        [HttpGet]
        [Route("GetTicketsWithReservation")]
        [CheckClaims("roleid", "21")]

        public async Task<List<Ticket>> GetTicketsWithReservation()
        {
            return await _ticketService.GetTicketsWithReservation();
        }
        [HttpGet]
        [Route("GetTicketsByReservationId/{reservationId}")]
        [CheckClaims("roleid", "21")]

        public List<Ticket> GetTicketsByReservationId(int reservationId)
        {
            return _ticketService.GetTicketsByReservationId(reservationId);
        }



    }
}
