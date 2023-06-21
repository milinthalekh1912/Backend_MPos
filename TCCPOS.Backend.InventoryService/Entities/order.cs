using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class order
    {
        public string order_id { get; set; } = null!;
        public string? order_no { get; set; }
        public int? order_type { get; set; }
        public double? total { get; set; }
        public double? total_discount { get; set; }
        public string? user_id { get; set; }
        public string? merchant_id { get; set; }
        public string? supplier_id { get; set; }
        public string? coupon_id { get; set; }
        public string? address_id { get; set; }
        public int? payment_status { get; set; }
        public string? delivery_detail_id { get; set; }
        public int? order_status { get; set; }
        public bool? is_read { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
