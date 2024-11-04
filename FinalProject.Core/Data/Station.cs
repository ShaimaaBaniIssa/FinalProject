using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Core.Data
{
    public partial class Station
    {
        public Station()
        {
            Testimonials = new HashSet<Testimonial>();
            Trips = new HashSet<Trip>();
        }

        public decimal Stationid { get; set; }
        public string? Stationname { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Imagepath { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        [NotMapped]
        public decimal? AverageRating { get; set; }
    }
}
