using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
    public class TestimonialDTO
    {
        public decimal Testimonialid { get; set; }
        public decimal? Rating { get; set; }
        public string? Commenttext { get; set; }
        public decimal Stationid { get; set; }
        public decimal Customerid { get; set; }

        public string? Fname { get; set; }
        public string? Stationname { get; set; }
    }
}
