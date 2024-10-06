using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public List<Ticket> GetAllTickets()
        {
            return _ticketService.GetAllTickets();
        }
        [HttpGet]
        [Route("GetTicketById/{id}")]
        public Ticket GetTicketById(int id)
        {
            return _ticketService.GetTicketById(id);
        }
        [HttpPost]
        [Route("CreateTicket")]
        public void CreateTicket(Ticket ticket)
        {
            _ticketService.CreateTicket(ticket);
        }
        [HttpPut]

        [Route("UpdateTicket")]
        public void UpdateTicket(Ticket ticket)
        {
            _ticketService.UpdateTicket(ticket);
        }
        [HttpDelete]
        [Route("DeleteTicket/{id}")]
        public void DeleteTicket(int id)
        {
            _ticketService.DeleteTicket(id);
        }
        [HttpGet]
        [Route("GetTicketsWithReservation")]
        public async Task<List<Ticket>> GetTicketsWithReservation()
        {
            return await _ticketService.GetTicketsWithReservation();
        }
        [HttpGet]
        [Route("GetTicketsByReservationId/{reservationId}")]
        public List<Ticket> GetTicketsByReservationId(int reservationId)
        {
            return _ticketService.GetTicketsByReservationId(reservationId);
        }



    }
}
