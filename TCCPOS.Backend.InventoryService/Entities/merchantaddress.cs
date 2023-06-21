using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class merchantaddress
    {
        public string address_id { get; set; } = null!;
        public string merchant_id { get; set; } = null!;
        public string? address_title { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? address3 { get; set; }
        public string? zipcode { get; set; }
        public string? phone_number { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
