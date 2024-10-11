using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface ITestimonialServices
    {
        List<TestimonialDTO> GetAllTestimonials();
        TestimonialDTO GetTestimonialById(int id);
        void CreateTestimonial(Testimonial testimonial);
        void UpdateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
    }
}
