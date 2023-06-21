using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class merchant
    {
        public string merchant_id { get; set; } = null!;
        public string? merchant_name { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
        public string? price_tier_id { get; set; }
        public string? merchant_group_id { get; set; }
    }
}
