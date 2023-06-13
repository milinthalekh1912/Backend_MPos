﻿using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class pricetier
    {
        public string price_tier_id { get; set; } = null!;
        public string? price_tier_group_id { get; set; }
        public string? sku_id { get; set; }
        public double? price { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
