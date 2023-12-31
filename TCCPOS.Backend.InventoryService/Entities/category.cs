﻿using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class category
    {
        public string category_id { get; set; } = null!;
        public string? th_name { get; set; }
        public string? en_name { get; set; }
        public string? description { get; set; }
        public string? image_url { get; set; }
        public string? supplier_id { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
