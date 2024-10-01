using System;
using System.Collections.Generic;

namespace FinalProject.Core.Data
{
    public partial class Login
    {
        public decimal Loginid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal? Customerid { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Role? Role { get; set; }
    }
}
