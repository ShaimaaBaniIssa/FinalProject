using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAllTickets();
        }
        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetTicketById(id);
        }
        public void CreateTicket(Ticket ticket)
        {
            _ticketRepository.CreateTicket(ticket);
        }
        public void UpdateTicket(Ticket ticket)
        {
            _ticketRepository.UpdateTicket(ticket);
        }
        public void DeleteTicket(int id)
        {
            _ticketRepository.DeleteTicket(id);
        }


    }

}

