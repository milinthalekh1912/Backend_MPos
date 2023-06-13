using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class pricetiergroup
    {
        public string id { get; set; } = null!;
        public string? supplier_id { get; set; }
        public string? price_tier_title { get; set; }
        public string? description { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
