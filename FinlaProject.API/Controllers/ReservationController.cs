using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using FinalProject.Core.Utility;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using System.IO;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IEmailSender _emailSender;
        private readonly ICustomerService _customerService;
        private readonly ITripScheduleService _tripScheduleService;
        private readonly ITicketService _ticketService;
        private readonly ITripService _tripService;
        private readonly IBankCardService _bankCardService;
        private readonly ISeatServices _seatServices;
        public ReservationController(IReservationService reservationService, IPdfGenerator pdfGenerator, IEmailSender emailSender, 
            ICustomerService customerService,ITripScheduleService tripScheduleService,
            ITicketService ticketService,
            ITripService tripService,IBankCardService bankCardService,
            ISeatServices seatServices)
        {
            _reservationService = reservationService;
            _pdfGenerator = pdfGenerator;
            _emailSender = emailSender;
            _customerService = customerService;
            _tripScheduleService = tripScheduleService;
            _ticketService = ticketService;
            _tripService = tripService;
            _bankCardService = bankCardService;
            _seatServices = seatServices;
        }
        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return _reservationService.GetAllReservations();
        }
        [HttpGet]
        [Route("GetReservationById/{id}")]
        public Reservation GetReservationById(int id)
        {
            return _reservationService.GetReservationById(id);
        }
       
        [HttpPost]
        [Route("CreateReservation")]
        public IActionResult CreateReservation([FromBody] CreateReservationDto createReservationDto
            )
        {
            //  procedure tripscheduleId ,, trip
            var trip = _tripService.GetTripById(createReservationDto.tripId);


            // calculate price by get the price from the trip * num of tickets
            var numOfTickets = createReservationDto.tickets.Count();
            decimal price = numOfTickets * trip.Price.Value;


            // payment 
            if(!_bankCardService.Pay(createReservationDto.bankcard, price))
            {
                return BadRequest("Invalid Card");

            }
            // create reservation and return the id
            int reservationId = _reservationService.CreateReservation(
                new Reservation
                {
                    Customerid = createReservationDto.customerId,
                    Reservationdate = createReservationDto.reservationDate,
                    RDate = DateTime.Now,
                    Totalprice = price,
                    Tripscheduleid = createReservationDto.tripScheduleId
                });
            // create the tickets
            foreach (var ticket in createReservationDto.tickets)
            {
                ticket.Reservationid = reservationId;
                _ticketService.CreateTicket(ticket);
                // reserve seat
                _seatServices.ReserveSeat((int)ticket.Seatid, createReservationDto.tripScheduleId);

            }

            // get invoices info
            var invoices = _reservationService.GetInvoice(reservationId);

            //get user email
            var customer = _customerService.GetCustomerById(createReservationDto.customerId);
            // generate pdf
            foreach (var invoice in invoices)
            {
                var pdf = _pdfGenerator.GetInvoice(invoice).GeneratePdf();

                // send it to the user
                _emailSender.SendEmail(customer.Email, "Booking Invoice",
                   $"Train Ticket",
                   pdf);
            }
            return Ok();

        }
        [HttpPut]

        [Route("UpdateReservation")]
        public void UpdateReservation(Reservation reservation)
        {
            _reservationService.UpdateReservation(reservation);
        }
        [HttpDelete]
        [Route("DeleteReservation/{id}")]
        public void DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
        }
        [HttpGet]
        [Route("GetReservationsWithCustomer")]
        public async Task<List<Reservation>> GetReservationsWithCustomer()
        {
            return await _reservationService.GetReservationsWithCustomer();
        }
        [HttpGet]
        [Route("GetReservationsWithCustomer/{custId}")]
        public List<Reservation> GetReservationByCustId(int custId)
        {
            return _reservationService.GetReservationByCustId(custId);
        }



        [HttpGet]
        [Route("MonthlyAnnualReports")]
        public List<MonthlyAnnualDTO> MonthlyAnnualReports(int? month, int year)
        {

            return _reservationService.MonthlyAnnualReports(month, year);
        }

    }



}
