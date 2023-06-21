using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class promotion
    {
        public string promotion_id { get; set; } = null!;
        public int? promotion_type { get; set; }
        public string? supplier_id { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string? description { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
        public bool? isActive { get; set; }
        public string? conditions { get; set; }
    }
}
