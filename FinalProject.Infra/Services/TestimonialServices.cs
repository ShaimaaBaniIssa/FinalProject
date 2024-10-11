using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class TestimonialServices: ITestimonialServices
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialServices(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public List<TestimonialDTO> GetAllTestimonials()
        {
           return _testimonialRepository.GetAllTestimonials();
        }
        public TestimonialDTO GetTestimonialById(int id)
        {
            return _testimonialRepository.GetTestimonialById(id);

        }
        public void CreateTestimonial(Testimonial testimonial)
        {

            _testimonialRepository.CreateTestimonial(testimonial);
        }
        public void UpdateTestimonial(Testimonial testimonial)
        {

            _testimonialRepository.UpdateTestimonial(testimonial);
        }

        public void DeleteTestimonial(int id)
        {
            _testimonialRepository.DeleteTestimonial(id);
        }
    }
}
