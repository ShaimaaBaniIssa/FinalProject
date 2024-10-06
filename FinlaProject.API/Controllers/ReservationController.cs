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
        public ReservationController(IReservationService reservationService, IPdfGenerator pdfGenerator, IEmailSender emailSender, ICustomerService customerService)
        {
            _reservationService = reservationService;
            _pdfGenerator = pdfGenerator;
            _emailSender = emailSender;
            _customerService = customerService;
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
        public void CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
           
            // شغل محمد
           
               int resId= _reservationService.CreateReservationAndTickets(
                    createReservationDto.TripScheduleId,
                    createReservationDto.CustomerId,
                    createReservationDto.ReservationDate,
                    createReservationDto.SeatIds,
                    createReservationDto.FullName,
                    createReservationDto.NationalId,
                    createReservationDto.DateOfBirth,
                    createReservationDto.Gender,
                    createReservationDto.TicketPrice);




            // get invoices info
            var invoices = _reservationService.GetInvoice(resId);

            //get user email
            var customer = _customerService.GetCustomerById(createReservationDto.CustomerId);
            // generate pdf
            foreach (var invoice in invoices)
            {
                var pdf = _pdfGenerator.GetInvoice(invoice).GeneratePdf();

                // send it to the user
                _emailSender.SendEmail(customer.Email, "Booking Invoice",
                   $"Train Ticket",
                   pdf);
            }
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
        
       

    }



}
