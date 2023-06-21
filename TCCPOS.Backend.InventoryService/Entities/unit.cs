using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class unit
    {
        public string unit_id { get; set; } = null!;
        public string? unit_name { get; set; }
        public int? unit1 { get; set; }
        public string? supplier_id { get; set; }
        public string? created_by { get; set; }
        public string? updated_by { get; set; }
        public DateTime? updated_date { get; set; }
        public DateTime? created_date { get; set; }
    }
}
