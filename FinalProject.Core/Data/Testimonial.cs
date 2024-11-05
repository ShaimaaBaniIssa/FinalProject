using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public decimal? Customerid { get; set; }
        public decimal? Stationid { get; set; }
        public decimal? Rating { get; set; }
        public string? Commenttext { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Station? Station { get; set; }
        public bool? IsApprove { get; set; }

    }
}
