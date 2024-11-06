using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialServices _testimonialServices;
        public TestimonialController(ITestimonialServices testimonialServices)
        {
            _testimonialServices = testimonialServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<TestimonialDTO> GetAllTestimonials()
        {
            return _testimonialServices.GetAllTestimonials();
        }

        [HttpGet]
        [Route("GetApprovedTestimonials")]
        [AllowAnonymous]
        public List<TestimonialDTO> GetApprovedTestimonials()
        {
            return _testimonialServices.GetApprovedTestimonials();

        }

        [HttpGet]
        [Route("GetUnApprovedTestimonials")]
        [CheckClaims("roleid", "21")]
        public List<TestimonialDTO> GetUnApprovedTestimonials()
        {
            return _testimonialServices.GetUnApprovedTestimonials();

        }

        [HttpGet]
        [Route("GetTestimonialById/{id}")]
        [CheckClaims("roleid", "21")]

        public TestimonialDTO GetTestimonialById(int id)
        {
            return _testimonialServices.GetTestimonialById(id);

        }

        [HttpPost]
        [Route("CreateTestimonial")]
        [CheckClaims("roleid", "1")]
        public void CreateTestimonial(Testimonial testimonial)
        {

            _testimonialServices.CreateTestimonial(testimonial);
        }

        [HttpPut]
        [Route("UpdateTestimonial")]
        [CheckClaims("roleid", "21")]
        public void UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialServices.UpdateTestimonial(testimonial);
        }


        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        [CheckClaims("roleid", "21")]

        public void DeleteTestimonial(int id)
        {
            _testimonialServices.DeleteTestimonial(id);
        }
    }
}
