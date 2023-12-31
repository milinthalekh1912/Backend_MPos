﻿using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class orderdetail
    {
        public string order_item_id { get; set; } = null!;
        public string? order_id { get; set; }
        public string? sku_id { get; set; }
        public string? title { get; set; }
        public int? amount { get; set; }
        public double? price { get; set; }
        public double? full_price { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
        public string? promotion_id { get; set; }
    }
}
