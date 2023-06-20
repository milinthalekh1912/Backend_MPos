using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class sku
    {
        public string sku_id { get; set; } = null!;
        public string? title { get; set; }
        public string? alias_title { get; set; }
        public string? barcode { get; set; }
        public string? barcode_url { get; set; }
        public string? image_url { get; set; }
        public string? category_id { get; set; }
        public string? supplier_id { get; set; }
        public string? unit_id { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}
