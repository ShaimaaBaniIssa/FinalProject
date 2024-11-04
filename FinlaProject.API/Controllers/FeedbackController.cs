using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;
        public FeedbackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }


        [HttpGet]
        [CheckClaims("roleid", "21")]

        public List<Feedback> GetAllFeedback()
        {

            return _feedbackServices.GetAllFeedback();
             
        }


        [HttpPost]
        [Route("CreateFeedback")]
        [AllowAnonymous]
        public void CreateFeedback(Feedback feedback)
        {
            _feedbackServices.CreateFeedback(feedback);



        }
    }
}
