﻿using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class deliverydetail
    {
        public string delivery_detail_id { get; set; } = null!;
        public string? order_id { get; set; }
        public double? cost { get; set; }
        public DateTime? estimate_date { get; set; }
        public DateTime? due_date { get; set; }
        public bool? is_express { get; set; }
        public string? note { get; set; }
        public sbyte? delivery_status_id { get; set; }
    }
}
