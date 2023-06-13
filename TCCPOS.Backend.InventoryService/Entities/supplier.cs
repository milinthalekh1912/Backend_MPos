using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class supplier
    {
        public string supplier_id { get; set; } = null!;
        public string? supplier_name { get; set; }
        public string? supplier_image { get; set; }
        public bool? is_show_price { get; set; }
        public bool? is_show_stock { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
