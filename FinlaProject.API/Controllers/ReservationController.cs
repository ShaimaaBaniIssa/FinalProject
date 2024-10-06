using FinalProject.Core.Data;
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
        public void CreateReservation(Reservation reservation)
        {
            _reservationService.CreateReservation(reservation);
            // شغل محمد


            // get invoice info
            var invoice = _reservationService.GetInvoice((int)reservation.Reservationid);
           
            // generate pdf
            var pdf = _pdfGenerator.GetInvoice(invoice).GeneratePdf();

            //get user email
            var customer = _customerService.GetCustomerById((int)reservation.Customerid);

            // send it to the user
             _emailSender.SendEmail(customer.Email, "Booking Invoice",
                $"Thank you for choosing {invoice.Stationname} for your upcoming stay. We are delighted to have you as our guest and look forward to providing you with an exceptional experience.\n\nPlease find your booking invoice attached to this email for your reference.",
                pdf);
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
