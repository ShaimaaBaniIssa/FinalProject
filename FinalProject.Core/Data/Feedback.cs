using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Feedback
    {
        public decimal Feedbackid { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Message { get; set; }
    }
}
