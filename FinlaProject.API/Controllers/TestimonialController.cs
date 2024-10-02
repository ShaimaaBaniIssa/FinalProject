using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialServices _testimonialServices;
        public TestimonialController(ITestimonialServices testimonialServices)
        {
            _testimonialServices = testimonialServices;
        }

        [HttpGet]
        public List<Testimonial> GetAllTestimonials()
        {
            return _testimonialServices.GetAllTestimonials();
        }


        [HttpGet]
        [Route("GetTestimonialById/{id}")]
        public Testimonial GetTestimonialById(int id)
        {
            return _testimonialServices.GetTestimonialById(id);

        }

        [HttpPost]
        [Route("CreateTestimonial")]
        public void CreateTestimonial(Testimonial testimonial)
        {

            _testimonialServices.CreateTestimonial(testimonial);
        }

        [HttpPut]
        [Route("UpdateTestimonial")]
        public void UpdateTestimonial(Testimonial testimonial)
        {

            _testimonialServices.UpdateTestimonial(testimonial);
        }


        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public void DeleteTestimonial(int id)
        {
            _testimonialServices.DeleteTestimonial(id);
        }
    }
}
