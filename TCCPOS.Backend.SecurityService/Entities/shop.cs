using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class shop
    {
        public string shop_id { get; set; } = null!;
        public string? shop_name { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
        public string? price_tier_id { get; set; }
        public string? shop_group_id { get; set; }
    }
}
