using FinalProject.Core.Data;
using FinalProject.Core.Services;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SeatController : ControllerBase
    {
        private readonly ISeatServices _seatServices;
        public SeatController(ISeatServices seatServices)
        {
            _seatServices = seatServices;
        }

        [HttpGet]
        [CheckClaims("roleid", "21")]
        public List<Seat> GetAllSeats()
        {
            return _seatServices.GetAllSeats();
        }

        [HttpGet]
        [Route("GetSeatById/{id}")]
        [CheckClaims("roleid", "21")]

        public Seat GetSeatById(int id)
        {
            return _seatServices.GetSeatById(id);

        }

        [HttpPost]
        [Route("CreateSeat")]
        [CheckClaims("roleid", "21")]

        public IActionResult CreateSeat(Seat seat)
        {
            try
            {
                _seatServices.CreateSeat(seat);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("error occured while creating the seat");
            }
        }


        [HttpPut]
        [Route("UpdateSeat")]
        [CheckClaims("roleid", "21")]

        public IActionResult UpdateSeat(Seat seat)
        {
            try
            {
                _seatServices.UpdateSeat(seat);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("cannot update this seat");
            }

        }

        [HttpDelete]
        [Route("DeleteSeat/{id}")]
        [CheckClaims("roleid", "21")]

        public IActionResult DeleteSeat(int id)
        {
            try
            {
                _seatServices.DeleteSeat(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("cannot delete this seat");
            }
        }

        [HttpGet]
        [Route("GetSeatByTrainId/{trainid}")]
        [AllowAnonymous]
        public List<Seat> GetSeatByTrainId(int trainid)
        {
            return _seatServices.GetSeatByTrainId(trainid);
        }

    }
}
