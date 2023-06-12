using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class customer_address
    {
        public string CustomerAddressID { get; set; } = null!;
        public string? CustomerID { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Subdistrict { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? Zipcode { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
