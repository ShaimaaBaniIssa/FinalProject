using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Logins = new HashSet<Login>();
            Reservations = new HashSet<Reservation>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Customerid { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
