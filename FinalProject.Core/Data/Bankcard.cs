using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Bankcard
    {
        public decimal Id { get; set; }
        public string? Cardnumber { get; set; }
        public string? Cvv { get; set; }
        public DateTime? Expirydate { get; set; }
        public string? Cardholdername { get; set; }
        public decimal? Balance { get; set; }
        public string? Cardtype { get; set; }
    }
}
