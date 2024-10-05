using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTO
{
    public class Registration
    {

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public decimal? Phonenumber { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal? Customerid { get; set; }
        public decimal? Roleid { get; set; }
    }
}
